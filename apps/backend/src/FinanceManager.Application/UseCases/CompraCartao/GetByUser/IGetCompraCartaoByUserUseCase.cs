using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.CompraCartao.GetByUser
{
    public interface IGetCompraCartaoByUserUseCase
    {
        Task<GetCompraCartaoByUserResponse> ExecuteAsync(GetCompraCartaoByUserRequest request);
    }
}
