using FrioAPI.Application.UseCases.Recibos.Delete;
using FrioAPI.Application.UseCases.Recibos.GetAll;
using FrioAPI.Application.UseCases.Recibos.GetById;
using FrioAPI.Application.UseCases.Recibos.Register;
using FrioAPI.Application.UseCases.Recibos.Update;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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
            [FromBody] RequestReciboJson request)
        {
             byte[] arquivo = await useCase.Execute(request);
             return File(arquivo, MediaTypeNames.Application.Pdf, $"recibo-{request.NomeCliente}.pdf");
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

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(typeof(ResponseRecibosJson), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetReciboById(
            [FromServices] IGetReciboByIdUseCase useCase,
            [FromRoute] long id)
        {
            var response = await useCase.Execute(id);

            return Ok(response);
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> UpdateRecibo(
            [FromServices] IUpdateReciboUseCase useCase,
            [FromRoute] long id,
            [FromBody] RequestReciboJson request)
        {
            await useCase.Execute(id, request);
            return NoContent();
        }

        [HttpDelete]
        [Route("{id}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status404NotFound)]
        public async Task<IActionResult> DeleteRecibo(
            [FromServices] IDeleteReciboUseCase useCase,
            [FromRoute] long id)
        {
            await useCase.Execute(id);
            return NoContent();
        }


    }
}
