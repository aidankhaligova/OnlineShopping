using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Mappers
{
    public class OrderMapper:BaseMapper<Order,OrderModel>
    {
        public override Order Map(OrderModel orderModel)
        {
            Order order = new Order();
            order.Id = orderModel.Id;
            order.Address = orderModel.Address;

            CustomerMapper customerMapper = new CustomerMapper();
            order.Customer = customerMapper.Map(orderModel.Customer);

            order.Note = orderModel.Note;
            return order;
        }

        public override OrderModel Map(Order order)
        {
            OrderModel orderModel = new OrderModel();

            orderModel.Id = order.Id;
            orderModel.Address = order.Address;
            orderModel.Note = order.Note;

            CustomerMapper customerMapper = new CustomerMapper();
            orderModel.Customer = customerMapper.Map(order.Customer);

            return orderModel;

        }
    }
}
