using System;

namespace FinanceManager.Application.UseCases.ContaReceber.Create
{
    public class CreateContaReceberRequest
    {
        public Guid UserId { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataRecebimento { get; set; }
        public string Categoria { get; set; } = default!;
    }
}
