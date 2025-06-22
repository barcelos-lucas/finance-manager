using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;                    
using FinanceManager.Domain.Entities;                      
using FinanceManager.Application.UseCases.ContaPagar.GetByUser; 



namespace FinanceManager.Application.UseCases.ContaPagar.GetByUser
{
    public class GetContaPagarByUserUseCase : IGetContaPagarByUserUseCase
    {
        private readonly IContaPagarRepository _repository;

        public GetContaPagarByUserUseCase(IContaPagarRepository repository)
            => _repository = repository;

        public async Task<GetContaPagarByUserResponse> ExecuteAsync(GetContaPagarByUserRequest request)
        {
            var entities = await _repository.GetByUserAsync(request.UserId);

            var items = entities.Select(e => new ContaPagarDto
            {
                Id = e.Id,
                Descricao = e.Descricao,
                Valor = e.Valor,
                DataVencimento = e.DataVencimento,
                Status = e.Status,
                Categoria = e.Categoria,
                CreatedAt = e.CreatedAt
            });

            return new GetContaPagarByUserResponse { Items = items };
        }
    }
}
