using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Mappers
{
    public class OrderDetailMapper:BaseMapper<OrderDetail,OrderDetailModel>
    {
        public override OrderDetail Map(OrderDetailModel orderDetailModel)
        {
            OrderMapper orderMapper = new OrderMapper();
            ProductMapper productMapper = new ProductMapper();

            OrderDetail orderDetail = new OrderDetail();

            orderDetail.Order = orderMapper.Map(orderDetailModel.Order);
            orderDetail.OrderCount = orderDetailModel.OrderCount;
            orderDetail.Product = productMapper.Map(orderDetailModel.Product);

            return orderDetail;
        }

        public override OrderDetailModel Map(OrderDetail orderDetail)
        {
            OrderMapper orderMapper = new OrderMapper();
            ProductMapper productMapper = new ProductMapper();
            OrderDetailModel orderDetailModel = new OrderDetailModel();
            orderDetailModel.Product = productMapper.Map(orderDetail.Product);
            orderDetailModel.OrderCount = orderDetail.OrderCount;
            orderDetailModel.Order = orderMapper.Map(orderDetail.Order);
            return orderDetailModel;
        }
    }
}
