using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public interface IAccountData
    {
        IEnumerable<Account> GetAll();
    }
    public class InMemoryAccountData : IAccountData
    {
        readonly List<Account> accounts;
        public InMemoryAccountData()
        {
            accounts = new List<Account>();
            {
                new Account { Id = 1, accountType = 1, customerId = 1, transactionType = 1 };
                new Account { Id = 2, accountType = 2, customerId = 1, transactionType = 1 };
                new Account { Id = 3, accountType = 1, customerId = 1, transactionType = 1 };
                new Account { Id = 4, accountType = 1, customerId = 2, transactionType = 1 };
                new Account { Id = 5, accountType = 2, customerId = 2, transactionType = 1 };
                new Account { Id = 6, accountType = 2, customerId = 2, transactionType = 1 };
                new Account { Id = 7, accountType = 1, customerId = 3, transactionType = 1 };
                new Account { Id = 8, accountType = 1, customerId = 3, transactionType = 1 };
                new Account { Id = 9, accountType = 3, customerId = 3, transactionType = 1 };
            };
        }

        public IEnumerable<Account> GetAll()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Account> GetTransactionByCustomerID(int customerID)
        {
            return from r in accounts
                   where r.customerId == customerID
                   select r;
        }
    }
}
