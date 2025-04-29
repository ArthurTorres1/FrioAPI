using System.Linq;
using System.Runtime.ConstrainedExecution;
using AutoMapper;
using FrioAPI.Application.UseCases.Recibos.Reports.Pdf;
using FrioAPI.Application.UseCases.ViaCep;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using FrioAPI.Domain.Entities;
using FrioAPI.Domain.Repositories;
using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Exception.ExceptionsBase;


namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public class RegisterReciboUseCase : IRegisterReciboUseCase
    {
        private readonly IRecibosWriteOnlyRepository _recibosRepository;
        private readonly IUnidadeDeTrabalho _unidadeDeTrabalho;
        private readonly IMapper _mapper;
        private readonly IGenerateRecibosReportPdfUseCase _pdfRecibo;
        private readonly IBuscaEnderecoViaCep _viacepUseCase;

        public RegisterReciboUseCase(
            IRecibosWriteOnlyRepository repository,
            IUnidadeDeTrabalho unidadeDeTrabalho,
            IMapper mapper,
            IGenerateRecibosReportPdfUseCase pdfRecibo,
            IBuscaEnderecoViaCep viaCepUseCase
            )
        {
            _recibosRepository = repository;
            _unidadeDeTrabalho = unidadeDeTrabalho;
            _mapper = mapper;
            _pdfRecibo = pdfRecibo;
            _viacepUseCase = viaCepUseCase;
        }
        public async Task<byte[]> Execute(RequestReciboJson request) 
        {
            if (!string.IsNullOrWhiteSpace(request.CEP))
            {
                var cepLimpo = new string(request.CEP.Where(char.IsDigit).ToArray());
                var endereco = await _viacepUseCase.BuscaCep(cepLimpo);

                if (endereco == null)
                    throw new ArgumentException("CEP inválido ou não encontrado. Por favor, informe um CEP válido ou preencha os campos manualmente.");

                //preenche automaticamente apenas se os campos estiverem vazios
                request.Logradouro = string.IsNullOrWhiteSpace(request.Logradouro) ? endereco.Logradouro : request.Logradouro;
                request.Bairro = string.IsNullOrWhiteSpace(request.Bairro) ? endereco.Bairro : request.Bairro;
                request.Cidade = string.IsNullOrWhiteSpace(request.Cidade) ? endereco.Localidade : request.Cidade;
                request.UF = string.IsNullOrWhiteSpace(request.UF) ? endereco.Uf : request.UF;
            }

            Validate(request);

            var entity = _mapper.Map<Recibo>(request);
            //salvando no banco de dados
            await _recibosRepository.Add(entity);
            await _unidadeDeTrabalho.Commit();

            return await _pdfRecibo.ReciboClientePdf(entity);
        }

        private void Validate(RequestReciboJson request) 
        {
            var validator = new ReciboValidator();  
            var result = validator.Validate(request);

            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
            
        }
    }
}
