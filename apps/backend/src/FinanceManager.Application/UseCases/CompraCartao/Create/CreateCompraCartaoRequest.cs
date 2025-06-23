using System;

namespace FinanceManager.Application.UseCases.CompraCartao.Create
{
    public class CreateCompraCartaoRequest
    {
        public Guid UserId { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
        public string Categoria { get; set; } = default!;
        public string Cartao { get; set; } = default!;
        public int Parcelas { get; set; }
    }
}
