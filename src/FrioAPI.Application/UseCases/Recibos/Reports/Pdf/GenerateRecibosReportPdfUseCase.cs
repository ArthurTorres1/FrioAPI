
using FrioAPI.Application.UseCases.Recibos.Reports.Pdf.Fonts;
using FrioAPI.Domain.Repositories.Recibos;
using PdfSharp.Fonts;

namespace FrioAPI.Application.UseCases.Recibos.Reports.Pdf
{
    public class GenerateRecibosReportPdfUseCase : IGenerateRecibosReportPdfUseCase
    {
        private const string SIMBOLO_MOEDA = "R$";
        private readonly IRecibosReadOnlyRepository _repository;
        public GenerateRecibosReportPdfUseCase(IRecibosReadOnlyRepository repository)
        {
            _repository = repository;
            GlobalFontSettings.FontResolver = new RecibosReportFontResolver();
        }

        public async Task<byte[]> Execute(DateOnly mes)
        {
            var recibos = await _repository.FilterByMonth(mes);
            if (recibos.Count == 0)
                return [];


            return [];
        }
    }
}
