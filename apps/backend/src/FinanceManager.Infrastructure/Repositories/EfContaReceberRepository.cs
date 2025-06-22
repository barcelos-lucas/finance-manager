using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories
{
    public class EfContaReceberRepository : IContaReceberRepository
    {
        private readonly AppDbContext _context;
        public EfContaReceberRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(ContaReceber conta)
        {
            await _context.ContasReceber.AddAsync(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<ContaReceber?> GetByIdAsync(Guid id)
        {
            return await _context.ContasReceber
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<ContaReceber>> GetByUserAsync(Guid userId)
        {
            return await _context.ContasReceber
                                 .AsNoTracking()
                                 .Where(c => c.UserId == userId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(ContaReceber conta)
        {
            _context.ContasReceber.Update(conta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new ContaReceber { Id = id };
            _context.ContasReceber.Remove(entity);
            await _context.SaveChangesAsync();
        }
    }
}
