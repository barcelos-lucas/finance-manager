namespace FinanceManager.Application.UseCases.Relatorio.GetSaldoMensal
{
    public class GetSaldoMensalResponse
    {
        public decimal TotalReceitas { get; set; }
        public decimal TotalDespesas { get; set; }
        public decimal Saldo { get; set; }
    }
}
