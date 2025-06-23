using FinanceManager.Application.UseCases.Relatorio.Exportar;
using FinanceManager.Application.UseCases.Relatorio.GetDespesaPorCategoria;
using FinanceManager.Application.UseCases.Relatorio.GetSaldoMensal;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceManager.API.Controllers
{
    [ApiController]
    [Route("api/relatorios")]
    public class RelatorioController : ControllerBase
    {
        private readonly IGetDespesaPorCategoriaUseCase _ucDespesa;
        private readonly IGetSaldoMensalUseCase _ucSaldo;
        private readonly IExportarRelatorioUseCase _ucExportar;

        public RelatorioController(
            IGetDespesaPorCategoriaUseCase ucDespesa,
            IGetSaldoMensalUseCase ucSaldo,
            IExportarRelatorioUseCase ucExportar)
        {
            _ucDespesa = ucDespesa;
            _ucSaldo = ucSaldo;
            _ucExportar = ucExportar;
        }

        // GET api/relatorios/despesas-mes/2025/6
        [HttpGet("despesas-mes/{ano:int}/{mes:int}")]
        public async Task<IActionResult> GetDespesas(int ano, int mes)
        {
            var req = new GetDespesaPorCategoriaRequest { Ano = ano, Mes = mes };
            var resp = await _ucDespesa.ExecuteAsync(req);
            return Ok(resp);
        }

        // GET api/relatorios/saldo-mes/2025/6
        [HttpGet("saldo-mes/{ano:int}/{mes:int}")]
        public async Task<IActionResult> GetSaldo(int ano, int mes)
        {
            var req = new GetSaldoMensalRequest { Ano = ano, Mes = mes };
            var resp = await _ucSaldo.ExecuteAsync(req);
            return Ok(resp);
        }

        /// <summary>
        /// Exporta relatório em XLSX (padrão), CSV ou PDF.
        /// Exemplo: GET api/relatorios/exportar/2025/6?formato=csv
        /// </summary>
        [HttpGet("exportar/{ano:int}/{mes:int}")]
        public async Task<IActionResult> Exportar(
            int ano,
            int mes,
            [FromQuery] string formato = "xlsx")
        {
            // Chama o UseCase, que retorna um FileResult pronto
            var fileResult = await _ucExportar.ExecuteAsync(ano, mes, formato);
            return fileResult;
        }
    }
}
