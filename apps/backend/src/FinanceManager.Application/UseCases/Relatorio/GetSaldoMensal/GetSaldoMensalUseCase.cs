using System.Threading.Tasks;
using FinanceManager.Application.UseCases.Relatorio.GetDespesaPorCategoria;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.Relatorio.GetSaldoMensal
{
    public class GetSaldoMensalUseCase : IGetSaldoMensalUseCase
    {
        private readonly IRelatorioRepository _repository;

        public GetSaldoMensalUseCase(IRelatorioRepository repository)
            => _repository = repository;

        public async Task<GetSaldoMensalResponse> ExecuteAsync(GetSaldoMensalRequest req)
        {
            // usa o repositório para buscar o SaldoMensal
            SaldoMensal s = await _repository.GetSaldoMensalAsync(req.Ano, req.Mes);

            return new GetSaldoMensalResponse
            {
                TotalReceitas = s.TotalReceitas,
                TotalDespesas = s.TotalDespesas,
                Saldo = s.Saldo
            };
        }
    }
}
