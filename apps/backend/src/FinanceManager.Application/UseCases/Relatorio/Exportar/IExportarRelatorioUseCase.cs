using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Relatorio.Exportar
{
    public interface IExportarRelatorioUseCase
    {

        Task<FileResult> ExecuteAsync(int ano, int mes, string formato = "xlsx");
    }
}
