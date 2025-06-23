using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.CompraCartao.Update
{
    public interface IUpdateCompraCartaoUseCase
    {
        Task ExecuteAsync(UpdateCompraCartaoRequest request);
    }
}
