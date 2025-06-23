using System;

namespace FinanceManager.Domain.Entities
{
    public class CompraCartao
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
        public string Categoria { get; set; } = default!;
        public string Cartao { get; set; } = default!;      
        public int Parcelas { get; set; }                    
        public DateTime CreatedAt { get; set; }
    }
}
