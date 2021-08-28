using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Abstract
{
    public interface IOrderRepository
    {
        int Add(Order order);
        bool Update(Order order);
        List<Order> Get();
    }
}
