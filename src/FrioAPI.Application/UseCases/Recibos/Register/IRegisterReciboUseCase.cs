﻿using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;

namespace FrioAPI.Application.UseCases.Recibos.Register
{
    public interface IRegisterReciboUseCase
    {
        Task<byte[]> Execute(RequestReciboJson request);
    }
}
