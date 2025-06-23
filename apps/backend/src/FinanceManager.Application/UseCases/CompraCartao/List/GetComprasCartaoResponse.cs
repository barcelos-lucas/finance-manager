using System.Collections.Generic;

namespace FinanceManager.Application.UseCases.CompraCartao.List
{
    public class GetComprasCartaoResponse
    {
        public IEnumerable<CompraCartaoDto> Items { get; set; }
            = new List<CompraCartaoDto>();
    }
}
