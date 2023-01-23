using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace abc_bank
{
    public interface ICustomerData
    {
        IEnumerable<Customer> All();
    }
    public class inMemoryCustomerData : ICustomerData
    {
        readonly List<Customer> customers;
        public inMemoryCustomerData()
        {
            customers = new List<Customer>()
            {
                new Customer { Id = 1, Name = "Scott Scottlander" },
                new Customer { Id = 2, Name = "Ann Scottlander" },
                new Customer { Id = 3, Name = "Billy Williams" }
            };
        }

        public IEnumerable<Customer> All()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Customer> GetCustomersByName(string name)
        {
            return from r in customers
                   where string.IsNullOrEmpty(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
