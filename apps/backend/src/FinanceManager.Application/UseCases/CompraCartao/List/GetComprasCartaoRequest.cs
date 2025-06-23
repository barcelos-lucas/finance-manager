using System;

namespace FinanceManager.Application.UseCases.CompraCartao.List
{
    public class GetComprasCartaoRequest
    {
        public Guid UserId { get; set; }
        public string? Cartao { get; set; }
        public DateTime? DataInicio { get; set; }
        public DateTime? DataFim { get; set; }
    }
}
