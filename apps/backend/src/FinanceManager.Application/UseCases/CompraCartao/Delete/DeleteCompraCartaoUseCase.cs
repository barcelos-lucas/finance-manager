using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.CompraCartao.Delete
{
    public class DeleteCompraCartaoUseCase : IDeleteCompraCartaoUseCase
    {
        private readonly ICompraCartaoRepository _repository;
        public DeleteCompraCartaoUseCase(ICompraCartaoRepository repository) => _repository = repository;
        public Task ExecuteAsync(Guid id) => _repository.DeleteAsync(id);
    }
}
