namespace FinanceManager.Domain.Entities
{
    /// <summary>
    /// Representa o saldo (receitas − despesas) de um mês.
    /// </summary>
    public class SaldoMensal
    {
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo => TotalReceitas - TotalDespesas;
    }
}
