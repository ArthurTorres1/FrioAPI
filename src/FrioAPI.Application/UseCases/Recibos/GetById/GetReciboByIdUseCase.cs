using AutoMapper;
using FrioAPI.Communication.Responses;
using FrioAPI.Domain.Repositories.Recibos;
using FrioAPI.Exception;
using FrioAPI.Exception.ExceptionsBase;

namespace FrioAPI.Application.UseCases.Recibos.GetById
{
    public class GetReciboByIdUseCase : IGetReciboByIdUseCase
    {
        private readonly IRecibosReadOnlyRepository _recibosRepository;
        private readonly IMapper _mapper;

        public GetReciboByIdUseCase(
            IRecibosReadOnlyRepository reciposRepository,
            IMapper mapper)
        {
            _recibosRepository = reciposRepository;
            _mapper = mapper;
        }
        public async Task<ResponseReciboJson> Execute(long id)
        {
            var result = await _recibosRepository.GetById(id);

            if (result is null)
                throw new NotFoundException(ResourceErrorMessages.RECIBO_NAO_ENCONTRADO);

            return _mapper.Map<ResponseReciboJson>(result);
        }
    }
}
