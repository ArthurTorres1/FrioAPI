﻿using FrioAPI.Application.UseCases.Recibos.GetAll;
using FrioAPI.Application.UseCases.Recibos.Register;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FrioAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecibosController : ControllerBase
    {
        [HttpPost]
        [ProducesResponseType(typeof(ResponseRegisteredReciboJson), StatusCodes.Status201Created)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterReciboUseCase useCase,
            [FromBody] RequestRegisterReciboJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);

        }

        [HttpGet]
        [ProducesResponseType(typeof(ResponseRecibosJson), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetAllRecibos([FromServices] IGetAllReciboUseCase useCase)
        {
            var response = await useCase.Execute();

            if (response.Recibos.Count != 0)
                return Ok(response);

            return NoContent();
        }

    }
}
