using System.Collections.Generic;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Domain.Interfaces
{
    /// <summary>
    /// Reposit�rio para consultas de relat�rios financeiros.
    /// </summary>
    public interface IRelatorioRepository
    {
        /// <summary>
        /// Retorna o total de despesas (ContasPagar + ComprasCartao) 
        /// para o m�s e ano informados, agrupado por categoria.
        /// </summary>
        /// 
        Task<IEnumerable<DespesaPorCategoria>>
            GetDespesaPorCategoriaAsync(int ano, int mes);

        Task<SaldoMensal> GetSaldoMensalAsync(int ano, int mes);

    }
}
