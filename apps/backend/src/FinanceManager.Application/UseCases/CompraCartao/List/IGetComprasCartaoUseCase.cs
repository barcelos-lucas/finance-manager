using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.CompraCartao.List
{
    public interface IGetComprasCartaoUseCase
    {
        Task<GetComprasCartaoResponse> ExecuteAsync(GetComprasCartaoRequest request);
    }
}
