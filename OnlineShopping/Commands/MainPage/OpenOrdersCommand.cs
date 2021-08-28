using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.MainPage
{
    public class OpenOrdersCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenOrdersCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            List<Order> orders = DB.OrderRepository.Get();
            List<OrderModel> orderModels = new List<OrderModel>();
            OrderMapper orderMapper = new OrderMapper();


            for (int i = 0; i < orders.Count; i++)
            {
                Order order = orders[i];

                OrderModel orderModel = orderMapper.Map(order);
                orderModel.No = i + 1;

                orderModels.Add(orderModel);
            }

            Enumeration.Enumerate(orderModels);

            OrderViewModel orderViewModel = new OrderViewModel();
            orderViewModel.AllOrders = orderModels;
            orderViewModel.Orders = new ObservableCollection<OrderModel>(orderModels);

            OrdersControl ordersControl = new OrdersControl();
            ordersControl.DataContext = orderViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(ordersControl);
        }
    }
}
