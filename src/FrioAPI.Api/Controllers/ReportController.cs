using FrioAPI.Application.UseCases.Recibos.Reports.Excel;
using FrioAPI.Application.UseCases.Recibos.Reports.Pdf;
using FrioAPI.Communication.Requests;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

namespace FrioAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ControllerBase
    {
        [HttpGet("excel")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetExcel(
            [FromServices] IGenerateRecibosReportExcelUseCase useCase,
            [FromHeader] DateOnly mes)
        {
            byte[] arquivo = await useCase.Execute(mes);

            if(arquivo.Length > 0 )
                return File(arquivo, MediaTypeNames.Application.Octet, $"recibos-{mes:MMMM}.xlsx");

            return NoContent();
        }

        [HttpGet("pdf")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public async Task<IActionResult> GetPdf(
            [FromServices] IGenerateRecibosReportPdfUseCase useCase,
            [FromQuery] DateOnly mes)
        {
            byte[] arquivo = await useCase.Execute(mes);

            if (arquivo.Length > 0)
                return File(arquivo, MediaTypeNames.Application.Pdf, $"recibos-{mes:MMMM}.pdf");

            return NoContent();
        }
    }
}
