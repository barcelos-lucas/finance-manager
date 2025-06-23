using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.Relatorio.GetDespesaPorCategoria
{
    public interface IGetDespesaPorCategoriaUseCase
    {
        Task<GetDespesaPorCategoriaResponse> ExecuteAsync(GetDespesaPorCategoriaRequest request);
    }
}
