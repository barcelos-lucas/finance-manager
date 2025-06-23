using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories
{
    public class EfCompraCartaoRepository : ICompraCartaoRepository
    {
        private readonly AppDbContext _context;
        public EfCompraCartaoRepository(AppDbContext context) => _context = context;

        public async Task AddAsync(CompraCartao compra)
        {
            await _context.ComprasCartao.AddAsync(compra);
            await _context.SaveChangesAsync();
        }

        public async Task<CompraCartao?> GetByIdAsync(Guid id)
        {
            return await _context.ComprasCartao
                                 .AsNoTracking()
                                 .FirstOrDefaultAsync(c => c.Id == id);
        }

        public async Task<IEnumerable<CompraCartao>> GetByUserAsync(Guid userId)
        {
            return await _context.ComprasCartao
                                 .AsNoTracking()
                                 .Where(c => c.UserId == userId)
                                 .ToListAsync();
        }

        public async Task UpdateAsync(CompraCartao compra)
        {
            _context.ComprasCartao.Update(compra);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Guid id)
        {
            var entity = new CompraCartao { Id = id };
            _context.ComprasCartao.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<CompraCartao>> GetByFilterAsync(
            Guid userId,
            string? cartao,
            DateTime? dataInicio,
            DateTime? dataFim)
        {
            var query = _context.ComprasCartao
                .AsNoTracking()
                .Where(c => c.UserId == userId);

            if (!string.IsNullOrEmpty(cartao))
                query = query.Where(c => c.Cartao == cartao);

            if (dataInicio.HasValue)
                query = query.Where(c => c.DataCompra >= dataInicio.Value);

            if (dataFim.HasValue)
                query = query.Where(c => c.DataCompra <= dataFim.Value);

            return await query
                .OrderByDescending(c => c.DataCompra)
                .ToListAsync();
        }



    }
}
