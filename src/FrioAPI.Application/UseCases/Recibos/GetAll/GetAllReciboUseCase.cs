using AutoMapper;
using FrioAPI.Communication.Responses;
using FrioAPI.Domain.Repositories.Recibos;

namespace FrioAPI.Application.UseCases.Recibos.GetAll
{
    public class GetAllReciboUseCase : IGetAllReciboUseCase
    {
        private readonly IRecibosReadOnlyRepository _recibosRepository;
        private readonly IMapper _mapper;
        public GetAllReciboUseCase(
            IRecibosReadOnlyRepository recibosRepository,
            IMapper mapper)
        {
            _recibosRepository = recibosRepository;
            _mapper = mapper;
        }
        public async Task<ResponseRecibosJson> Execute()
        {
            var result = await _recibosRepository.GetAll();
            return new ResponseRecibosJson
            {
                Recibos = _mapper.Map<List<ResponseShortReciboJson>>(result)
            };
        }
    }
}
