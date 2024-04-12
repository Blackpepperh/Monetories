using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain.DTOs
{
    public class TransactionDetailDto
    {
        public Guid TransactionDetailId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string Notes { get; set; }
        public CategoryDto Category { get; set; }
        public TransactionHeaderDto TransactionHeader { get; set; }
    }
}