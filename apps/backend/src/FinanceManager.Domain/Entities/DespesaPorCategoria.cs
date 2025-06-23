using System;

namespace FinanceManager.Domain.Entities
{
    /// <summary>
    /// Representa o total de despesas em um m�s, agrupadas por categoria.
    /// </summary>
  
    public class DespesaPorCategoria
    {
        public string Categoria { get; set; } = default!;
        public decimal Total { get; set; }
    }
}
