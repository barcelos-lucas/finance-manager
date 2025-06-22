using System.Linq;
using System.Threading.Tasks;
using FinanceManager.Domain.Interfaces;
using System;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaReceber.GetByUser
{
    public class GetContaReceberByUserUseCase : IGetContaReceberByUserUseCase
    {
        private readonly IContaReceberRepository _repository;
        public GetContaReceberByUserUseCase(IContaReceberRepository repository)
            => _repository = repository;

        public async Task<GetContaReceberByUserResponse> ExecuteAsync(GetContaReceberByUserRequest request)
        {
            var list = await _repository.GetByUserAsync(request.UserId);

            var items = list.Select(c => new ContaReceberDto
            {
                Id = c.Id,
                UserId = c.UserId,
                Descricao = c.Descricao,
                Valor = c.Valor,
                DataRecebimento = c.DataRecebimento,
                Categoria = c.Categoria,
                Status = c.Status,
                CreatedAt = c.CreatedAt
            });

            return new GetContaReceberByUserResponse { Items = items };
        }
    }
}
