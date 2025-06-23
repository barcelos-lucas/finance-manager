using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Relatorio.GetSaldoMensal
{
    public interface IGetSaldoMensalUseCase
    {
        Task<GetSaldoMensalResponse> ExecuteAsync(GetSaldoMensalRequest req);
    }
}
