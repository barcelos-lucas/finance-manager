using System.Collections.Generic;

namespace FinanceManager.Application.UseCases.Relatorio.GetDespesaPorCategoria
{
    public class GetDespesaPorCategoriaResponse
    {
        public IEnumerable<DespesaPorCategoriaDto> Items { get; set; } = new List<DespesaPorCategoriaDto>();
    }

    public class DespesaPorCategoriaDto
    {
        public string Categoria { get; set; } = default!;
        public decimal Total { get; set; }
    }
}
