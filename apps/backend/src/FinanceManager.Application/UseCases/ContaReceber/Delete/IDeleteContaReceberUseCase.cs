using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaReceber.Delete
{
    public interface IDeleteContaReceberUseCase
    {
        Task ExecuteAsync(Guid id);
    }
}
