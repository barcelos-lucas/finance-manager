using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.Relatorio.GetDespesaPorCategoria
{
    public class GetDespesaPorCategoriaUseCase : IGetDespesaPorCategoriaUseCase
    {
        private readonly IRelatorioRepository _repository;

        public GetDespesaPorCategoriaUseCase(IRelatorioRepository repository)
            => _repository = repository;

        public async Task<GetDespesaPorCategoriaResponse> ExecuteAsync(GetDespesaPorCategoriaRequest request)
        {
            var dados = await _repository.GetDespesaPorCategoriaAsync(request.Ano, request.Mes);

            var items = dados.Select(d => new DespesaPorCategoriaDto
            {
                Categoria = d.Categoria,
                Total = d.Total
            });

            return new GetDespesaPorCategoriaResponse { Items = items };
        }
    }
}
