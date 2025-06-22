
using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.ContaPagar.Delete
{
    public class DeleteContaPagarUseCase : IDeleteContaPagarUseCase
    {
        private readonly IContaPagarRepository _repo;
        public DeleteContaPagarUseCase(IContaPagarRepository repo) => _repo = repo;

        public async Task ExecuteAsync(Guid id)
        {
            await _repo.DeleteAsync(id);
        }
    }
}