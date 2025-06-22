using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaPagar.Update
{
    public interface IUpdateContaPagarUseCase
    {
        Task ExecuteAsync(UpdateContaPagarRequest request);
    }
}