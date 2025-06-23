using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Domain.Interfaces
{
    public interface ICompraCartaoRepository
    {
        Task AddAsync(CompraCartao compra);
        Task<CompraCartao?> GetByIdAsync(Guid id);
        Task<IEnumerable<CompraCartao>> GetByUserAsync(Guid userId);
        Task UpdateAsync(CompraCartao compra);
        Task DeleteAsync(Guid id);

        //busca de compras por filtro
        Task<IEnumerable<CompraCartao>> GetByFilterAsync(
            Guid userId,
            string? cartao,
            DateTime? dataInicio,
            DateTime? dataFim);
            
}
}
