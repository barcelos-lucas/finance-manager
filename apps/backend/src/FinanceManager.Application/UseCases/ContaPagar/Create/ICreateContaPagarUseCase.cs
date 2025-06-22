using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaPagar.Create
{
    public interface ICreateContaPagarUseCase
    {
        Task<CreateContaPagarResponse> ExecuteAsync(CreateContaPagarRequest request);
    }
}