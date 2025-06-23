using FinanceManager.Domain.Entities;
using FinanceManager.Domain.Interfaces;

namespace FinanceManager.Application.UseCases.CompraCartao.Update
{
    public class UpdateCompraCartaoUseCase : IUpdateCompraCartaoUseCase
    {
        private readonly ICompraCartaoRepository _repository;

        public UpdateCompraCartaoUseCase(ICompraCartaoRepository repository)
            => _repository = repository;

        public async Task ExecuteAsync(UpdateCompraCartaoRequest request)
        {
            var compraCartao = await _repository.GetByIdAsync(request.Id);

            if (compraCartao is null)
                throw new KeyNotFoundException($"CompraCartao com Id='{request.Id}' não foi encontrada.");

            compraCartao.Descricao = request.Descricao;
            compraCartao.Valor = request.Valor;
            compraCartao.DataCompra = request.DataCompra;
            compraCartao.Categoria = request.Categoria;
            compraCartao.Cartao = request.Cartao;
            compraCartao.Parcelas = request.Parcelas;

            await _repository.UpdateAsync(compraCartao);
        }
    }
}
