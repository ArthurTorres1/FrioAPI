﻿using ClosedXML.Excel;
using FrioAPI.Domain.Reports;
using FrioAPI.Domain.Repositories.Recibos;

namespace FrioAPI.Application.UseCases.Recibos.Reports.Excel
{
    public class GenerateRecibosReportExcelUseCase : IGenerateRecibosReportExcelUseCase
    {
        private readonly IRecibosReadOnlyRepository _repository;
        public GenerateRecibosReportExcelUseCase(IRecibosReadOnlyRepository repository)
        {
            _repository = repository;   
        }
        public async Task<byte[]> Execute(DateOnly mes)
        {
            var recibos = await _repository.FilterByMonth(mes);

            var pastaDeTrabalho = new XLWorkbook();

            pastaDeTrabalho.Author = "Assisência técnica especializada";
            pastaDeTrabalho.Style.Font.FontSize = 12;
            pastaDeTrabalho.Style.Font.FontName = "Times New Roman";

            //Nome da planilha vai ser o mes e o ano que o usuario mandou, o "Y" pega o mes e o ano por escrito 
            var planilha = pastaDeTrabalho.Worksheets.Add(mes.ToString("Y"));

            InsertHeader(planilha);

            var file = new MemoryStream();
            pastaDeTrabalho.SaveAs(file);

            return file.ToArray();
        }

        private void InsertHeader(IXLWorksheet planilha)
        {
            planilha.Cell("A1").Value = ResourceReportGenerationMessages.NOME_CLIENTE;
            planilha.Cell("B1").Value = ResourceReportGenerationMessages.EQUIPAMENTO;
            planilha.Cell("C1").Value = ResourceReportGenerationMessages.DESCRICAO_SERVICO;
            planilha.Cell("D1").Value = ResourceReportGenerationMessages.UF;
            planilha.Cell("E1").Value = ResourceReportGenerationMessages.CIDADE;
            planilha.Cell("F1").Value = ResourceReportGenerationMessages.DATA;
            planilha.Cell("G1").Value = ResourceReportGenerationMessages.TOTAL;

            planilha.Cells("A1:G1").Style.Font.Bold = true;
            planilha.Cells("A1:G1").Style.Fill.BackgroundColor = XLColor.FromHtml("#aeff9e");

            planilha.Cell("A1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            planilha.Cell("B1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            planilha.Cell("C1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            planilha.Cell("D1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            planilha.Cell("E1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            planilha.Cell("F1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);
            planilha.Cell("G1").Style.Alignment.SetHorizontal(XLAlignmentHorizontalValues.Right);
        }
    }
}
