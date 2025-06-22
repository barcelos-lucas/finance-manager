using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Application.UseCases.ContaPagar.GetByUser;


namespace FinanceManager.Application.UseCases.ContaPagar.GetByUser
{
    public interface IGetContaPagarByUserUseCase
    {
        Task<GetContaPagarByUserResponse> ExecuteAsync(GetContaPagarByUserRequest request);
    }
}
