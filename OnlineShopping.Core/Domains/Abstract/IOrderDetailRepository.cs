using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Abstract
{
    public interface IOrderDetailRepository
    {
        int Add(OrderDetail orderDetail);
        bool Update(OrderDetail orderDetail);
        List<OrderDetail> Get();
        List<OrderDetail> GetOrderDetails(int orderId);
    }
}
