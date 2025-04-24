using FrioAPI.Domain.Entities;

namespace FrioAPI.Application.UseCases.Recibos.Reports.Pdf
{
    public interface IGenerateRecibosReportPdfUseCase
    {
        Task<byte[]> RelatorioMensalRecibosPdf(DateOnly mes);
        Task<byte[]> ReciboClientePdf(Recibo recibo);
    }
}
