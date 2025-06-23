using System;
using System.Collections.Generic;

namespace FinanceManager.Application.UseCases.CompraCartao.GetByUser
{
    public class GetCompraCartaoByUserResponse
    {
        public IEnumerable<CompraCartaoDto> Items { get; set; } = new List<CompraCartaoDto>();
    }

    public class CompraCartaoDto
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
