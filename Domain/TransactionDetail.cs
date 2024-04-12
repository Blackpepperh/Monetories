using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class TransactionDetail
    {
        public Guid TransactionDetailId { get; set; }
        public decimal TransactionAmount { get; set; }
        public string TransactionType { get; set; }
        public string Notes { get; set; }
        public Category Category { get; set; }
        public Guid CategoryId { get; set; }
        public TransactionHeader TransactionHeader { get; set; }
        public Guid TransactionHeaderId { get; set; }
    }
}