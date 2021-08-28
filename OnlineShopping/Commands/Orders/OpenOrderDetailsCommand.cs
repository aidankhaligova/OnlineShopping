using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Orders
{
    public class OpenOrderDetailsCommand : BaseOrderCommand
    {
        public OpenOrderDetailsCommand(OrderViewModel orderViewModel) : base(orderViewModel) { }
        public override void Execute(object parameter)
        {
            List<OrderDetail> orderDetails = DB.OrderDetailRepository.GetOrderDetails(orderViewModel.CurrentOrder.Id);
            List<OrderDetailModel> orderDetailModels = new List<OrderDetailModel>();
            OrderDetailMapper orderDetailMapper = new OrderDetailMapper();

            for (int i = 0; i < orderDetails.Count; i++)
            {
                OrderDetail orderDetail = orderDetails[i];

                OrderDetailModel orderDetailModel = orderDetailMapper.Map(orderDetail);
                orderDetailModel.No = i + 1;

                orderDetailModels.Add(orderDetailModel);
            }
            orderViewModel.OrderDetails = orderDetailModels;
            OrderInformation orderInformation = new OrderInformation();
            orderInformation.DataContext = orderViewModel;
            orderInformation.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            orderInformation.ShowDialog();
        }
    }
}
