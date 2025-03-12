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
        public IActionResult Register([FromBody] RequestRegisterReciboJson request)
        {
            try
            {
                var useCase = new RegisterReciboUseCase();
                var response = useCase.Execute(request);

                return Created(string.Empty, response);
            }
            catch (Exception ex)
            {
                
            }

        }
    }
}
