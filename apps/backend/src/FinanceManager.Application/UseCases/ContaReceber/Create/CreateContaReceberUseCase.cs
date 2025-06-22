using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.ContaReceber.Create
{
    public class CreateContaReceberUseCase : ICreateContaReceberUseCase
    {
        private readonly IContaReceberRepository _repository;
        public CreateContaReceberUseCase(IContaReceberRepository repository)
            => _repository = repository;

        public async Task<CreateContaReceberResponse> ExecuteAsync(CreateContaReceberRequest request)
        {
            var contaReceber = new FinanceManager.Domain.Entities.ContaReceber
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Descricao = request.Descricao,
                Valor = request.Valor,
                DataRecebimento = request.DataRecebimento,
                Categoria = request.Categoria,
                Status = "Pendente",
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(contaReceber);

            return new CreateContaReceberResponse { Id = contaReceber.Id };
        }
    }
}
