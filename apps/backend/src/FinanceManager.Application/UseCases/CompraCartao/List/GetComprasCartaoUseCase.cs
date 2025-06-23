using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.CompraCartao.List
{
    public class GetComprasCartaoUseCase : IGetComprasCartaoUseCase
    {
        private readonly ICompraCartaoRepository _repo;
        public GetComprasCartaoUseCase(ICompraCartaoRepository repo)
            => _repo = repo;

        public async Task<GetComprasCartaoResponse> ExecuteAsync(GetComprasCartaoRequest req)
        {
            var entidades = await _repo.GetByFilterAsync(
                req.UserId,
                req.Cartao,
                req.DataInicio,
                req.DataFim);

            var items = entidades.Select(c => new CompraCartaoDto
            {
                Id = c.Id,
                Descricao = c.Descricao,
                Valor = c.Valor,
                DataCompra = c.DataCompra,
                Categoria = c.Categoria,
                Cartao = c.Cartao,
                Parcelas = c.Parcelas
            });

            return new GetComprasCartaoResponse { Items = items };
        }
    }
}
