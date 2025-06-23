using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace FinanceManager.Infrastructure.Repositories
{
    public class EfRelatorioRepository : IRelatorioRepository
    {
        private readonly AppDbContext _context;

        public EfRelatorioRepository(AppDbContext context)
            => _context = context;

        public async Task<IEnumerable<DespesaPorCategoria>> GetDespesaPorCategoriaAsync(int ano, int mes)
        {
            // 1) Filtra Contas a Pagar no mês/ano
            var contas = await _context.ContasPagar
                .AsNoTracking()
                .Where(c => c.DataVencimento.Year == ano && c.DataVencimento.Month == mes)
                .Select(c => new { c.Categoria, c.Valor })
                .ToListAsync();

            // 2) Filtra Compras de Cartão no mês/ano
            var compras = await _context.ComprasCartao
                .AsNoTracking()
                .Where(c => c.DataCompra.Year == ano && c.DataCompra.Month == mes)
                .Select(c => new { c.Categoria, c.Valor })
                .ToListAsync();

            // 3) Une e agrupa por categoria
            var todas = contas
                .Concat(compras)
                .GroupBy(x => x.Categoria)
                .Select(g => new DespesaPorCategoria
                {
                    Categoria = g.Key,
                    Total = g.Sum(x => x.Valor)
                });

            return todas;
        }

        public async Task<SaldoMensal> GetSaldoMensalAsync(int ano, int mes)
        {
            // soma receitas (ContasReceber) no mês
            var totalRec = await _context.ContasReceber
                .AsNoTracking()
                .Where(x => x.DataRecebimento.Year == ano && x.DataRecebimento.Month == mes)
                .SumAsync(x => (decimal?)x.Valor) ?? 0m;

            // soma despesas a pagar
            var totalPagar = await _context.ContasPagar
                .AsNoTracking()
                .Where(x => x.DataVencimento.Year == ano && x.DataVencimento.Month == mes)
                .SumAsync(x => (decimal?)x.Valor) ?? 0m;

            // soma despesas de cartão
            var totalCartao = await _context.ComprasCartao
                .AsNoTracking()
                .Where(x => x.DataCompra.Year == ano && x.DataCompra.Month == mes)
                .SumAsync(x => (decimal?)x.Valor) ?? 0m;

            return new SaldoMensal
            {
                TotalReceitas = totalRec,
                TotalDespesas = totalPagar + totalCartao
            };
        }

    }
}
