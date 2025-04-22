
using FrioAPI.Application.UseCases.Recibos.Reports.Pdf.Fonts;
using FrioAPI.Domain.Reports;
using FrioAPI.Domain.Repositories.Recibos;
using MigraDoc.DocumentObjectModel;
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

            var document =  CreateDocument(mes);
            return [];
        }

        private Document CreateDocument(DateOnly mes)
        {
            var document = new Document();

            document.Info.Title = $"{ResourceReportGenerationMessages.RECIBOS_PARA} {mes:Y}";
            document.Info.Author = "Assistência técnica especializada";

            var style = document.Styles["Normal"];
            style.Font.Name = FontHelper.RALEWAY_REGULAR;
            return document;
        }
    }
}
