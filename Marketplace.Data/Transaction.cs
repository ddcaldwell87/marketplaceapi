using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Data
{
    public class Transaction
    {
        public int TransactionId { get; set; }
        public int ProductId { get; set; }
        public int CustomerId { get; set; }
        public DateTimeOffset TransactionDate { get; set; }
    }
}
