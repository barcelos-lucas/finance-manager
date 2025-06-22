using System.Threading.Tasks;
using System;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;


namespace FinanceManager.Application.UseCases.ContaReceber.Update
{
	public interface IUpdateContaReceberUseCase
	{
		Task ExecuteAsync(UpdateContaReceberRequest request);
	}
}
