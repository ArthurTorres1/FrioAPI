using AutoMapper;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using FrioAPI.Domain.Entities;

namespace FrioAPI.Application.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            RequestToEntity();
            EntityToResponse();
        }

        private void RequestToEntity()
        {
            CreateMap<RequestRegisterReciboJson, Recibo>();
        }
        private void EntityToResponse()
        {
            CreateMap<Recibo, ResponseRegisteredReciboJson>();
        }
    }
}
