using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.CompraCartao.GetByUser
{
    public class GetCompraCartaoByUserUseCase : IGetCompraCartaoByUserUseCase
    {
        private readonly ICompraCartaoRepository _repository;
        public GetCompraCartaoByUserUseCase(ICompraCartaoRepository repository) => _repository = repository;

        public async Task<GetCompraCartaoByUserResponse> ExecuteAsync(GetCompraCartaoByUserRequest request)
        {
            var entities = await _repository.GetByUserAsync(request.UserId);
            var items = entities.Select(c => new CompraCartaoDto
            {
                Id = c.Id,
                UserId = c.UserId,
                Descricao = c.Descricao,
                Valor = c.Valor,
                DataCompra = c.DataCompra,
                Categoria = c.Categoria,
                Cartao = c.Cartao,
                Parcelas = c.Parcelas,
                CreatedAt = c.CreatedAt
            });
            return new GetCompraCartaoByUserResponse { Items = items };
        }
    }
}
