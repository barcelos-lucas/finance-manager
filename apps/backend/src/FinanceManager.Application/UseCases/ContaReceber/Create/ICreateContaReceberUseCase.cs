using System.Threading.Tasks;

namespace FinanceManager.Application.UseCases.ContaReceber.Create
{
    public interface ICreateContaReceberUseCase
    {
        Task<CreateContaReceberResponse> ExecuteAsync(CreateContaReceberRequest request);
    }
}
