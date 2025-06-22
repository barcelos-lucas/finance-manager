using System;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;

namespace FinanceManager.Application.UseCases.ContaReceber.GetByUser
{
    public class GetContaReceberByUserRequest
    {
        public Guid UserId { get; set; }
    }
}
