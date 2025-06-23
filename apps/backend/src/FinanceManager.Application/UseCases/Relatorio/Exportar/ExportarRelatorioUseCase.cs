using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OfficeOpenXml;
using OfficeOpenXml.Drawing.Chart;
using GemBox.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using FinanceManager.Application.UseCases.Relatorio.Exportar;
using FinanceManager.Application.UseCases.Relatorio.GetDespesaPorCategoria;
using FinanceManager.Application.UseCases.Relatorio.GetSaldoMensal;

namespace FinanceManager.Application.UseCases.Relatorio.Exportar
{
    public class ExportarRelatorioUseCase : IExportarRelatorioUseCase
    {
        private readonly IGetDespesaPorCategoriaUseCase _getPorCategoria;
        private readonly IGetSaldoMensalUseCase _getSaldoMensal;

        public ExportarRelatorioUseCase(
            IGetDespesaPorCategoriaUseCase getPorCategoria,
            IGetSaldoMensalUseCase getSaldoMensal)
        {
            _getPorCategoria = getPorCategoria;
            _getSaldoMensal = getSaldoMensal;
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");
        }

        public async Task<FileResult> ExecuteAsync(int ano, int mes, string formato = "xlsx")
        {
            // 1) Buscar dados
            var despReq = new GetDespesaPorCategoriaRequest { Ano = ano, Mes = mes };
            var despResp = await _getPorCategoria.ExecuteAsync(despReq);
            var cats = despResp.Items.ToList();
            var saldoReq = new GetSaldoMensalRequest { Ano = ano, Mes = mes };
            var saldoDto = await _getSaldoMensal.ExecuteAsync(saldoReq);

            // 2) CSV?
            if (string.Equals(formato, "csv", StringComparison.OrdinalIgnoreCase))
                return GerarCsv(ano, mes, cats, saldoDto);

            // 3) Gerar XLSX
            var ms = new MemoryStream();
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (var p = new ExcelPackage(ms))
            {
                // Planilha DespesasPorCategoria
                var ws1 = p.Workbook.Worksheets.Add("DespesasPorCategoria");
                ws1.Cells[1, 1].Value = "Categoria";
                ws1.Cells[1, 2].Value = "Total";
                for (int i = 0; i < cats.Count; i++)
                {
                    ws1.Cells[i + 2, 1].Value = cats[i].Categoria;
                    ws1.Cells[i + 2, 2].Value = cats[i].Total;
                }
                int lastRow1 = cats.Count + 1;

                // Gráfico de Pizza
                var pie = ws1.Drawings.AddChart("chartDespesa", eChartType.Pie) as ExcelPieChart;
                pie.Title.Text = "Despesas por Categoria";
                pie.Series.Add(
                    ws1.Cells[2, 2, lastRow1, 2],
                    ws1.Cells[2, 1, lastRow1, 1]);
                pie.SetPosition(1, 0, 3, 0);
                pie.SetSize(400, 300);

                // Planilha SaldoMensal
                var ws2 = p.Workbook.Worksheets.Add("SaldoMensal");
                ws2.Cells[1, 1].Value = "Ano";
                ws2.Cells[1, 2].Value = "Mês";
                ws2.Cells[1, 3].Value = "Receitas";
                ws2.Cells[1, 4].Value = "Despesas";
                ws2.Cells[1, 5].Value = "Saldo";

                ws2.Cells[2, 1].Value = ano;
                ws2.Cells[2, 2].Value = mes;
                ws2.Cells[2, 3].Value = saldoDto.TotalReceitas;
                ws2.Cells[2, 4].Value = saldoDto.TotalDespesas;
                ws2.Cells[2, 5].Value = saldoDto.Saldo;

                int lastRow2 = 2;

                // Gráfico de Linha
                var line = ws2.Drawings.AddChart("chartSaldo", eChartType.Line) as ExcelLineChart;
                line.Title.Text = "Evolução do Saldo";
                line.Series.Add(
                    ws2.Cells[2, 5, lastRow2, 5],
                    ws2.Cells[2, 2, lastRow2, 2]);
                line.SetPosition(1, 0, 3, 0);
                line.SetSize(600, 300);

                p.Save();
            }

            ms.Position = 0;

            // 4) PDF?
            if (string.Equals(formato, "pdf", StringComparison.OrdinalIgnoreCase))
                return GerarPdf(ano, mes, ms);

            // 5) XLSX padrão
            return new FileStreamResult(ms,
                "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet")
            {
                FileDownloadName = $"Relatorio_{ano}_{mes}.xlsx"
            };
        }

        private FileContentResult GerarCsv(
            int ano, int mes,
            IReadOnlyList<DespesaPorCategoriaDto> cats,
            GetSaldoMensalResponse saldo)
        {
            var sb = new StringBuilder();
            sb.AppendLine("Categoria;Total");
            foreach (var c in cats)
                sb.AppendLine($"{c.Categoria};{c.Total}");

            sb.AppendLine();
            sb.AppendLine("Ano;Mes;Receitas;Despesas;Saldo");
            sb.AppendLine($"{ano};{mes};{saldo.TotalReceitas};{saldo.TotalDespesas};{saldo.Saldo}");

            var bytes = Encoding.UTF8.GetBytes(sb.ToString());
            return new FileContentResult(bytes, "text/csv")
            {
                FileDownloadName = $"Relatorio_{ano}_{mes}.csv"
            };
        }

        private FileStreamResult GerarPdf(int ano, int mes, MemoryStream excelStream)
        {
            excelStream.Position = 0;
            var workbook = ExcelFile.Load(excelStream);
            var pdfStream = new MemoryStream();
            workbook.Save(pdfStream, SaveOptions.PdfDefault);
            pdfStream.Position = 0;

            return new FileStreamResult(pdfStream, "application/pdf")
            {
                FileDownloadName = $"Relatorio_{ano}_{mes}.pdf"
            };
        }
    }
}
