using Marketplace.Data;
using Marketplace.Models.Transaction;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Marketplace.Services
{
    public class TransactionService
    {
        private readonly int _customerId;
        private readonly int _productId;

        public TransactionService(){ }

        public TransactionService(int productId, int customerId)
        {
            _productId = productId;
            _customerId = customerId;
        }
        public TransactionDetails GetTransactionbyId(int transactionId)
        {
            using (var ctx = new ApplicationDbContext())
            {
                var entity =
                    ctx
                        .Transactions
                        .Single(e => e.TransactionId == transactionId);
                return
                    new TransactionDetails
                    {
                        TransactionId = entity.TransactionId,
                        ProductId = entity.ProductId,
                        ProductName = entity.ProductName,
                        ProductPrice = entity.ProductPrice,
                        ProductQuantity = entity.ProductQuantity,
                        ProductUpc = entity.ProductUpc,
                        TransactionDate = entity.TransactionDate,
                        CustomerId = entity.CustomerId
                    };
            }
        }
        public bool CreateTransaction(TransactionCreate model)
        {
            var entity =
               new Transaction
               {
                   TransactionId = model.TransactionId,
                   ProductId = model.ProductId,
                   CustomerId = model.CustomerId,
                   ProductName = model.ProductName,
                   ProductPrice = model.ProductPrice,
                   ProductQuantity = model.ProductQuantity,
                   ProductUpc = model.ProductUpc,
                   TransactionDate = model.TransactionDate
               };

            using (var ctx = new ApplicationDbContext())
            {
                ctx.Transactions.Add(entity);
                return ctx.SaveChanges() == 1;
            }
        }

        public ICollection<TransactionListItem> GetAllTransactions()
        {
            using (var ctx = new ApplicationDbContext())
            {
                var transactions =
                    ctx
                        .Transactions
                        .Select(
                            e => new TransactionListItem()
                            {
                                TransactionId = e.TransactionId,
                                ProductName = e.ProductName,
                                ProductQuantity = e.ProductQuantity,
                                ProductPrice = e.ProductPrice,
                                ProductUpc = e.ProductUpc,
                                ProductId = e.ProductId,
                                TransactionDate = e.TransactionDate
                            });

                return transactions.ToList();
            }
        }
    }
}
