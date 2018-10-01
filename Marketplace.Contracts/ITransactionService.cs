using Marketplace.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Contracts
{
    public interface ITransactionService
    {
        TransactionDetails GetTransactionById(int TransactionId);
        bool CreateTransaction(TransactionCreate model);
        ICollection<TransactionListItem> GetAllTransactions();        
    }
}
