﻿using System;

namespace FinanceManager.Domain.Entities
{
    public class ContaPagar
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Descricao { get; set; } = default!;
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; } = default!;
        public string Categoria { get; set; } = default!;
        public DateTime CreatedAt { get; set; }
    }
}
