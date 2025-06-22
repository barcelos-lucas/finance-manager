using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Domain.Interfaces
{
    public interface IContaPagarRepository
    {
        Task AddAsync(ContaPagar conta);
        Task<ContaPagar?> GetByIdAsync(Guid id);
        Task<IEnumerable<ContaPagar>> GetByUserAsync(Guid userId);
        Task UpdateAsync(ContaPagar conta);
        Task DeleteAsync(Guid id);
    }
}
