using FrioAPI.Application.UseCases.Recibos.Register;
using FrioAPI.Communication.Requests;
using Microsoft.AspNetCore.Mvc;

namespace FrioAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
