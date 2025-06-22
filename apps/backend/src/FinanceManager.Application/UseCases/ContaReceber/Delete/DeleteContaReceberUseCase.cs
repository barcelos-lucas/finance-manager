using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaReceber.Delete
{
    public class DeleteContaReceberUseCase : IDeleteContaReceberUseCase
    {
        private readonly IContaReceberRepository _repository;
        public DeleteContaReceberUseCase(IContaReceberRepository repository)
            => _repository = repository;

        public Task ExecuteAsync(Guid id)
            => _repository.DeleteAsync(id);
    }
}
