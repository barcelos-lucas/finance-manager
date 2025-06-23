using System;

namespace FinanceManager.Application.UseCases.CompraCartao.Update
{
    public class UpdateCompraCartaoRequest
    {
        public Guid Id { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataCompra { get; set; }
        public string Categoria { get; set; } = default!;
        public string Cartao { get; set; } = default!;
        public int Parcelas { get; set; }
    }
}
