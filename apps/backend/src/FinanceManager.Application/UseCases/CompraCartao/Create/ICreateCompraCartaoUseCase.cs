using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.CompraCartao.Create
{
    public interface ICreateCompraCartaoUseCase
    {
        Task<CreateCompraCartaoResponse> ExecuteAsync(CreateCompraCartaoRequest request);
    }
}
