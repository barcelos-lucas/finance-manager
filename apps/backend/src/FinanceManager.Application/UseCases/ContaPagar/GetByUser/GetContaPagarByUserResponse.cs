using System.Collections.Generic;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Application.UseCases.ContaPagar.GetByUser;


namespace FinanceManager.Application.UseCases.ContaPagar.GetByUser
{
    public class GetContaPagarByUserResponse
    {
       public IEnumerable<ContaPagarDto> Items { get; set; } = new List<ContaPagarDto>();
    }
}