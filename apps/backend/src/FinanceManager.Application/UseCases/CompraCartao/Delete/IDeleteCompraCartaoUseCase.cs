using System;
using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.CompraCartao.Delete
{
    public interface IDeleteCompraCartaoUseCase
    {
        Task ExecuteAsync(Guid id);
    }
}
