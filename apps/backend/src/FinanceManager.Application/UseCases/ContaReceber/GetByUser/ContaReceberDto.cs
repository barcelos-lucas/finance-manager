using System;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Application.UseCases.ContaReceber.GetByUser;



namespace FinanceManager.Application.UseCases.ContaReceber.GetByUser
{
    public class ContaReceberDto
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string Categoria { get; set; } = default!;
        public string Status { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
