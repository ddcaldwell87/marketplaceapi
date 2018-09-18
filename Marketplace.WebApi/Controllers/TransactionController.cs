using Marketplace.Data;
using Marketplace.Models.Customer;
using Marketplace.Models.Product;
using Marketplace.Models.Transaction;
using Marketplace.Services;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Marketplace.WebApi.Controllers
{
    [Authorize]
    public class TransactionController : ApiController
    {
        public IHttpActionResult GetAll()
        {
            TransactionService transactionService = new TransactionService();
            var transactions = transactionService.GetAllTransactions();
            return Ok(transactions);
        }

        public IHttpActionResult Get(int id)
        {
            TransactionService transactionService = new TransactionService();
            var transaction = transactionService.GetTransactionbyId(id);
            return Ok();
        }

        public IHttpActionResult Post(TransactionCreate Transaction)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var service = CreateTransactionService(Transaction);

            if (!service.CreateTransaction(Transaction))
                return InternalServerError();

            return Ok();
        }
        private TransactionService CreateTransactionService(TransactionCreate transaction)
        {
            return new TransactionService(transaction.CustomerId, transaction.ProductId);
        }
       
    }
}
