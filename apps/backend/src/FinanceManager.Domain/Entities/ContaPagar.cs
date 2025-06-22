using System;

namespace FinanceManager.Domain.Entities
{
    public class ContaPagar
    {
        public Guid Id { get; set; }
        public Guid UserId { get; set; }
        public string Descricao { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public string Status { get; set; } // Ex: "Pendente", "Pago", "Atrasado"
        public string Categoria { get; set; } // Ex: "Alimentação", "Transporte", "Saúde"
        public DateTime CreatedAt { get; set; }
    }


    }   