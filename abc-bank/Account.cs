using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace abc_bank
{
    public class Account : ITransactionData
    {
        internal readonly IEnumerable<Transaction> transactions;

        public int Id { get; set; }
        public int customerId { get; set; }
        public int accountType { get; set; }
        public int transactionType { get; set; }
        public double balance { get; set; }

        public enum AccountType
        {
            CHECKING,
            SAVINGS,
            MAXI_SAVINGS
        }
        public int GetAccountType(AccountType account)
        {
            if (account == AccountType.CHECKING) return 0;
            else if (account == AccountType.SAVINGS) return 1;
            else return 2;
        }

        //private static readonly Dictionary<string, AccountType> predefinedValues;

        //private readonly int accountType;
        //public List<Transaction> transactions;

        public Account OpenAccount(Customer customer, int type)
        {
            Account account = new Account();
            account.customerId = customer.Id;
            account.accountType = type; 
            //this.transactions = new List<Transaction>();
            return account;
        }


        public double InterestEarned(AccountType account) 
        {
            double amount = sumTransactions(account);
            if (account == AccountType.SAVINGS) {
                if (amount <= 1000)
                    return amount * 0.001;
                else
                    return 1 + (amount - 1000) * 0.002;

            } else if (account == AccountType.SAVINGS)
            {
                if (amount <= 1000)
                    return amount * 0.02;
                if (amount <= 2000)
                    return 20 + (amount - 1000) * 0.05;
                return 70 + (amount - 2000) * 0.1;
            }else
            { 
                    return amount * 0.001;
            }
        }

        public double sumTransactions(AccountType account) {
           return CheckIfTransactionsExist(customerId,account);
        }

        private double CheckIfTransactionsExist(int customerId, AccountType account)
        {
            throw new NotImplementedException();
        }

        IEnumerable<Transaction> GetAll()
        {
            return from r in transactions
                   where r.customerId == customerId
                   select r;

        }

        private double CheckIfTransactionsExist(Customer customer, Account account)
        {
            double amount = 0.0;
            List<Transaction> transactions = null;
            transactions.Add((Transaction)from r in transactions
                                          where r.customerId == customerId
                                          select r);
            foreach (Transaction t in transactions)
                amount += t.amount;
            return amount;
        }

        IEnumerable<Transaction> ITransactionData.GetAll()
        {
            throw new NotImplementedException();
        }
    }
}
