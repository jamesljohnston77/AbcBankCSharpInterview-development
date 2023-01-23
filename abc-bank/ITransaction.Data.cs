using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public interface ITransactionData
    {
        IEnumerable<Transaction> GetAll();
    }
    public class InMemoryTransactionData : ITransactionData
    {
        readonly List<Transaction> transactions;
        public InMemoryTransactionData()
        {
            transactions = new List<Transaction>();
            {
                new Transaction { Id = 1, accountType = 1, customerId = 1, transactionType = 1, };
                new Transaction { Id = 2, accountType = 2, customerId = 1, transactionType = 1 };
                new Transaction { Id = 3, accountType = 1, customerId = 1, transactionType = 1 };
                new Transaction { Id = 4, accountType = 1, customerId = 2, transactionType = 1 };
                new Transaction { Id = 5, accountType = 2, customerId = 2, transactionType = 1 };
                new Transaction { Id = 6, accountType = 2, customerId = 2, transactionType = 1 };
                new Transaction { Id = 7, accountType = 1, customerId = 3, transactionType = 1 };
                new Transaction { Id = 8, accountType = 1, customerId = 3, transactionType = 1 };
                new Transaction { Id = 9, accountType = 3, customerId = 3, transactionType = 1 };
            }
         }

        public IEnumerable<Transaction> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Transaction> GetTransactionByCustomerID(int customerID)
        {
            return from r in transactions
                   where r.customerId == customerID
                   select r;        
        }
    }
}
