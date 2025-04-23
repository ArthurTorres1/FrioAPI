namespace FrioAPI.Application.UseCases.Recibos.Reports.Pdf
{
    public interface IGenerateRecibosReportPdfUseCase
    {
        Task<byte[]> RelatorioMensalRecibosPdf(DateOnly mes);
    }
}
