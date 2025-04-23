using FrioAPI.Application.UseCases.Recibos.Reports.Pdf.Colors;
using FrioAPI.Application.UseCases.Recibos.Reports.Pdf.Fonts;
using FrioAPI.Domain.Reports;
using FrioAPI.Domain.Repositories.Recibos;
using MigraDoc.DocumentObjectModel;
using MigraDoc.DocumentObjectModel.Tables;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;

namespace FrioAPI.Application.UseCases.Recibos.Reports.Pdf
{
    public class GenerateRecibosReportPdfUseCase : IGenerateRecibosReportPdfUseCase
    {
        private const string SIMBOLO_MOEDA = "R$";
        private const int HEIGHT_ROW_TABLE_RECIBOS = 25;
        private readonly IRecibosReadOnlyRepository _repository;
        public GenerateRecibosReportPdfUseCase(IRecibosReadOnlyRepository repository)
        {
            _repository = repository;
            GlobalFontSettings.FontResolver = new RecibosReportFontResolver();
        }

        public async Task<byte[]> RelatorioMensalRecibosPdf(DateOnly mes)
        {
            var recibos = await _repository.FilterByMonth(mes);
            if (recibos.Count == 0)
                return [];

            var document = CreateDocument(mes);
            var page = CreatePage(document);

            CreateCabecalhoComFotoENome(page);

            var totalRecibosMensal = recibos.Sum(recibo => recibo.Total);
            CreateTotalRecibos(page, mes, totalRecibosMensal);

            foreach (var recibo in recibos)
            {
                var table = CreateRecibosTable(page);

                var row = table.AddRow();
                row.Height = HEIGHT_ROW_TABLE_RECIBOS;
                AddNomeClienteRecibo(row.Cells[0], recibo.NomeCliente);
                AddCabecalhoParaTotal(row.Cells[3]);

                row = table.AddRow();
                row.Height = HEIGHT_ROW_TABLE_RECIBOS;

                row.Cells[0].AddParagraph($"{recibo.Data:ddd dd MMM yyyy}");
                EstiloBaseParaInformacoesRecibo(row.Cells[0]);
                row.Cells[0].Format.LeftIndent = 10;

                row.Cells[1].AddParagraph($"{recibo.Data:t}");
                EstiloBaseParaInformacoesRecibo(row.Cells[1]);

                row.Cells[2].AddParagraph(recibo.Equipamento);
                EstiloBaseParaInformacoesRecibo(row.Cells[2]);

                AddValorTotalRecibo(row.Cells[3], recibo.Total);

                row = table.AddRow();
                row.Height = HEIGHT_ROW_TABLE_RECIBOS;
                EstiloBaseParaDescricaoEEndereco(row.Cells[0], "Endereço: ", $"{recibo.Bairro}, {recibo.Logradouro} - {recibo.Cidade}-{recibo.UF}");

                row = table.AddRow();
                row.Height = HEIGHT_ROW_TABLE_RECIBOS;
                EstiloBaseParaDescricaoEEndereco(row.Cells[0], "Descrição: ", recibo.DescricaoServico);

                AddEspacoEmBranco(table);
            }
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
        private void CreateCabecalhoComFotoENome(Section page)
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
        private Table CreateRecibosTable(Section page)
        {
            var table = page.AddTable();
            table.AddColumn("175").Format.Alignment = ParagraphAlignment.Left;
            table.AddColumn("95").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Center;
            table.AddColumn("120").Format.Alignment = ParagraphAlignment.Right;
            return table;
        }
        private void AddNomeClienteRecibo(Cell cell, string nomeCliente)
        {
            cell.AddParagraph(nomeCliente);
            cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelper.BLACK };
            cell.Shading.Color = ColorsHelper.ORANGE_LIGHT;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.MergeRight = 2;
            cell.Format.LeftIndent = 10;
        }
        private void AddCabecalhoParaTotal(Cell cell)
        {
            cell.AddParagraph(ResourceReportGenerationMessages.TOTAL);
            cell.Format.Font = new Font { Name = FontHelper.RALEWAY_BLACK, Size = 14, Color = ColorsHelper.WHITE };
            cell.Shading.Color = ColorsHelper.ORANGE_DARK;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }
        private void EstiloBaseParaInformacoesRecibo(Cell cell)
        {
            cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12, Color = ColorsHelper.BLACK };
            cell.Shading.Color = ColorsHelper.BLUE_DARK;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }
        private void EstiloBaseParaDescricaoEEndereco(Cell cell, string textoNegrito, string txtRegular)
        {
            var paragraph = cell.AddParagraph();
            if (!textoNegrito.IsValueNullOrEmpty())
            {
                var txtSubtituloNegrito = paragraph.AddFormattedText(textoNegrito);
                txtSubtituloNegrito.Font = new Font { Name = FontHelper.WORKSANS_BLACK, Size = 12 };   
            }

            paragraph.AddText(txtRegular);

            cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 12, Color = ColorsHelper.BLACK };
            cell.Shading.Color = ColorsHelper.BLUE_LIGHT;
            cell.VerticalAlignment = VerticalAlignment.Center;
            cell.MergeRight = 2;
            cell.Format.LeftIndent = 10;
        }
        private void AddValorTotalRecibo(Cell cell, decimal totalRecibo)
        {
            cell.AddParagraph($"+{totalRecibo} {SIMBOLO_MOEDA}");
            cell.Format.Font = new Font { Name = FontHelper.WORKSANS_REGULAR, Size = 14, Color = ColorsHelper.BLACK };
            cell.Shading.Color = ColorsHelper.WHITE;
            cell.VerticalAlignment = VerticalAlignment.Center;
        }
        private void AddEspacoEmBranco(Table table)
        {
            var row = table.AddRow();
            row.Height = 30;
            row.Borders.Visible = false;
        }
        private byte[] RenderDocuments(Document document)
        {
            var renderer = new PdfDocumentRenderer { Document = document };

            renderer.RenderDocument();

            using var arquivo = new MemoryStream();
            renderer.PdfDocument.Save(arquivo);

            return arquivo.ToArray();
        }

    }
}
