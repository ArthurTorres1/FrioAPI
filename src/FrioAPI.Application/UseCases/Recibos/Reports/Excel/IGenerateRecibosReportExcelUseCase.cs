namespace FrioAPI.Application.UseCases.Recibos.Reports.Excel
{
    public interface IGenerateRecibosReportExcelUseCase
    {
        Task<byte[]> Execute(DateOnly mes);
    }
}
