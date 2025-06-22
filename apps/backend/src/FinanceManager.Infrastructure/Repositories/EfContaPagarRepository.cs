using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories
{
    public class EfContaPagarRepository : IContaPagarRepository
    {
        private readonly AppDbContext _context;
        public EfContaPagarRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(ContaPagar conta)
        {
            await _context.ContasPagar.AddAsync(conta);
            await _context.SaveChangesAsync();
        }

        public async Task<ContaPagar?> GetByIdAsync(Guid id)
        {
            return await _context.ContasPagar
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<ContaPagar>> GetByUserAsync(Guid userId)
        {
            return await _context.ContasPagar
                                 .AsNoTracking()
                                 .Where(c => c.UserId == userId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(ContaPagar conta)
        {
            _context.ContasPagar.Update(conta);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = await _context.ContasPagar.FindAsync(id);
            if (entity != null)
            {
                _context.ContasPagar.Remove(entity);
                await _context.SaveChangesAsync();
            }
        }
    }
}
