
using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;


namespace FinanceManager.Application.UseCases.ContaPagar.Update
{
    public class UpdateContaPagarUseCase : IUpdateContaPagarUseCase
    {
        private readonly IContaPagarRepository _repository;

        public UpdateContaPagarUseCase(IContaPagarRepository repository) 
            => _repository = repository;

        public async Task ExecuteAsync(UpdateContaPagarRequest request)
        {
            var contaPagar = new FinanceManager.Domain.Entities.ContaPagar
            {
                Id = request.Id,
                Descricao = request.Descricao,
                Valor = request.Valor,
                DataVencimento = request.DataVencimento,
                Categoria = request.Categoria,
                Status = request.Status,
            };
            await _repository.UpdateAsync(contaPagar);
        }
    }
}

