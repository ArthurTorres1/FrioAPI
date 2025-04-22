namespace FrioAPI.Application.UseCases.Recibos.Reports.Pdf
{
    public interface IGenerateRecibosReportPdfUseCase
    {
        Task<byte[]> Execute(DateOnly mes);
    }
}
