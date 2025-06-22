using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.ContaReceber.Update
{
    public class UpdateContaReceberUseCase : IUpdateContaReceberUseCase
    {
        private readonly IContaReceberRepository _repository;
        public UpdateContaReceberUseCase(IContaReceberRepository repository)
            => _repository = repository;

        public async Task ExecuteAsync(UpdateContaReceberRequest request)
        {
            var contaReceber = new FinanceManager.Domain.Entities.ContaReceber
            {
                Id = request.Id,
                Descricao = request.Descricao,
                Valor = request.Valor,
                DataRecebimento = request.DataRecebimento,
                Categoria = request.Categoria,
                Status = request.Status,
                UserId = request.Id 
            };

            await _repository.UpdateAsync(contaReceber);
        }
    }
}
