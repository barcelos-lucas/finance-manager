using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaPagar.Delete
{
	public interface IDeleteContaPagarUseCase
	{
		Task ExecuteAsync(Guid id);
	}
}
