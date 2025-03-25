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
        public IActionResult Register([FromBody] RequestRegisterReciboJson request)
        {
            try
            {
                var useCase = new RegisterReciboUseCase();
                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (ArgumentException ex)
            {
                var errorResponse = new ResponseErrorJson(ex.Message);
                return BadRequest(errorResponse); 
            }
            catch
            {
                var errorResponse = new ResponseErrorJson("erro desconhecido");
                return StatusCode(StatusCodes.Status500InternalServerError, errorResponse);
            }

        }
    }
}
