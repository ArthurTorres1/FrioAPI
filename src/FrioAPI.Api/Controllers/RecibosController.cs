using FrioAPI.Application.UseCases.Recibos.Register;
using FrioAPI.Communication.Requests;
using FrioAPI.Communication.Responses;
using Microsoft.AspNetCore.Mvc;

namespace FrioAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(ResponseRegisteredReciboJson), StatusCodes.Status201Created)]
    [ProducesResponseType(typeof(ResponseErrorJson), StatusCodes.Status400BadRequest)]
    public class RecibosController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> Register(
            [FromServices] IRegisterReciboUseCase useCase,
            [FromBody] RequestRegisterReciboJson request)
        {
            var response = await useCase.Execute(request);

            return Created(string.Empty, response);

        }
    }
}
