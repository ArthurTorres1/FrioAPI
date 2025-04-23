
using FrioAPI.Application.UseCases.Recibos.Reports.Pdf.Fonts;
using FrioAPI.Domain.Entities;
using FrioAPI.Domain.Reports;
using FrioAPI.Domain.Repositories.Recibos;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;

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

            var document = CreateDocument(mes);
            var page = CreatePage(document);

            CreateHeaderWithProfileAndName(page);

            var totalRecibosMensal = recibos.Sum(recibo => recibo.Total);
            CreateTotalRecibos(page, mes, totalRecibosMensal);



            return RenderDocuments(document);
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
        private Section CreatePage(Document document)
        {
            var pagina = document.AddSection();

            pagina.PageSetup = document.DefaultPageSetup.Clone();
            pagina.PageSetup.PageFormat = PageFormat.A4;
            pagina.PageSetup.LeftMargin = 40;
            pagina.PageSetup.RightMargin = 40;
            pagina.PageSetup.TopMargin = 80;
            pagina.PageSetup.BottomMargin = 80;

            return pagina;
        }
        private byte[] RenderDocuments(Document document)
        {
            var renderer = new PdfDocumentRenderer { Document = document };

            renderer.RenderDocument();

            using var arquivo = new MemoryStream();
            renderer.PdfDocument.Save(arquivo);

            return arquivo.ToArray();
        }
        private void CreateHeaderWithProfileAndName(Section page)
        {
            var table = page.AddTable();
            table.AddColumn();
            table.AddColumn("400");

            var row = table.AddRow();

            var assembly = Assembly.GetExecutingAssembly();
            var directoryName = Path.GetDirectoryName(assembly.Location);
            var pathFile = Path.Combine(directoryName!, "Logo", "avatar_120x120.png");

            row.Cells[0].AddImage(pathFile);
            row.Cells[1].AddParagraph("Assistência técnica especializada");
            row.Cells[1].Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 20 };
            row.Cells[1].Format.Alignment = ParagraphAlignment.Right;
            row.Cells[1].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
        }
        private void CreateTotalRecibos(Section page, DateOnly mes, decimal totalRecibosMensal)
        {
            var paragraph = page.AddParagraph();
            paragraph.Format.SpaceBefore = "40";
            paragraph.Format.SpaceAfter = "40";

            var title = string.Format($"{ResourceReportGenerationMessages.TOTAL_RECIBOS_EM} {mes:Y}");
            paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });
            paragraph.AddLineBreak();

            paragraph.AddFormattedText($"{totalRecibosMensal} {SIMBOLO_MOEDA}", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50 });
        }
    }
}
