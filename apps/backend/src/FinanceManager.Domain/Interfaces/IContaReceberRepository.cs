using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Domain.Interfaces
{
    public interface IContaReceberRepository
    {
        Task AddAsync(ContaReceber conta);
        Task<ContaReceber?> GetByIdAsync(Guid id);
        Task<IEnumerable<ContaReceber>> GetByUserAsync(Guid userId);
        Task UpdateAsync(ContaReceber conta);
        Task DeleteAsync(Guid id);
    }
}
