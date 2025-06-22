
using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.ContaPagar.Create
{
    public class CreateContaPagarUseCase : ICreateContaPagarUseCase
    {
        private readonly IContaPagarRepository _repository;

        public CreateContaPagarUseCase(IContaPagarRepository repository)
            => _repository = repository;

        public async Task<CreateContaPagarResponse> ExecuteAsync(CreateContaPagarRequest request)
        {
            var contaPagar = new FinanceManager.Domain.Entities.ContaPagar 
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Descricao = request.Descricao,
                Valor = request.Valor,
                DataVencimento = request.DataVencimento,
                Categoria = request.Categoria,
                Status = "Pendente",
                CreatedAt = DateTime.UtcNow
            };

            await _repository.AddAsync(contaPagar);

            return new CreateContaPagarResponse { Id = contaPagar.Id };
        }
    }
}
