using System;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Application.UseCases.ContaPagar.GetByUser;



namespace FinanceManager.Application.UseCases.ContaPagar.GetByUser
{
    public class ContaPagarDto
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; } = default!;
        public string Categoria { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
