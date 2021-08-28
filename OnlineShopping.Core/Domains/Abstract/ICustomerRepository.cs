using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Abstract
{
    public interface ICustomerRepository
    {
        int Add(Customer customer);
        bool Update(Customer customer);
        List<Customer> Get();
        Customer Get(int id);
    }
}
