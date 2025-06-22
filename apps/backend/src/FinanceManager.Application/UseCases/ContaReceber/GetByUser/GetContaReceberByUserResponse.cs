using System.Collections.Generic;
using FinanceManager.Domain.Interfaces;
using FinanceManager.Domain.Entities;
using FinanceManager.Application.UseCases.ContaReceber.GetByUser;

namespace FinanceManager.Application.UseCases.ContaReceber.GetByUser
{
    public class GetContaReceberByUserResponse
    {
        public IEnumerable<ContaReceberDto> Items { get; set; } = new List<ContaReceberDto>();
    }

}
