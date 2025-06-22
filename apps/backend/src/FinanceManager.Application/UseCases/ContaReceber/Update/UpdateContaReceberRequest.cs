using System;
using System;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaReceber.Update
{
    public class UpdateContaReceberRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string Categoria { get; set; } = default!;
        public string Status { get; set; } = default!;
    }
}
