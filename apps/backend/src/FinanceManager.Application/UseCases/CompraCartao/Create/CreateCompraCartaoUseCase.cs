using System;
using System.Threading.Tasks;
using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.CompraCartao.Create
{
    public class CreateCompraCartaoUseCase : ICreateCompraCartaoUseCase
    {
        private readonly ICompraCartaoRepository _repository;
        public CreateCompraCartaoUseCase(ICompraCartaoRepository repository) => _repository = repository;

        public async Task<CreateCompraCartaoResponse> ExecuteAsync(CreateCompraCartaoRequest request)
        {
            var compraCartao = new FinanceManager.Domain.Entities.CompraCartao
            {
                Id = Guid.NewGuid(),
                UserId = request.UserId,
                Descricao = request.Descricao,
                Valor = request.Valor,
                DataCompra = request.DataCompra,
                Categoria = request.Categoria,
                Cartao = request.Cartao,
                Parcelas = request.Parcelas,
                CreatedAt = DateTime.UtcNow
            };
            await _repository.AddAsync(compraCartao);
            return new CreateCompraCartaoResponse { Id = compraCartao.Id };
        }
    }
}
