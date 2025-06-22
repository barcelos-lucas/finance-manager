using System;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Application.UseCases.ContaPagar.GetByUser;


namespace FinanceManager.Application.UseCases.ContaPagar.GetByUser
{
    public class GetContaPagarByUserRequest
    {
        public Guid UserId { get; set; }

    }
}