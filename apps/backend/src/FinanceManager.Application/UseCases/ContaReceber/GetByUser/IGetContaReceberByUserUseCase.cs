using System.Threading.Tasks;
using System;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaReceber.GetByUser
{
    public interface IGetContaReceberByUserUseCase
    {
        Task<GetContaReceberByUserResponse> ExecuteAsync(GetContaReceberByUserRequest request);
    }
}
