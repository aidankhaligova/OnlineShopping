using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.SmallWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace OnlineShopping.Commands.Orders
{
    public class OpenOrderAddWindowCommand : BaseOrderCommand
    {
        public OpenOrderAddWindowCommand(OrderViewModel orderViewModel) : base(orderViewModel) { }
        public override void Execute(object parameter)
        {
            List<Customer> customers = DB.CustomerRepository.Get();
            List<CustomerModel> customerModels = new List<CustomerModel>();
            CustomerMapper customerMapper = new CustomerMapper();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer customer = customers[i];

                CustomerModel customerModel = customerMapper.Map(customer);

                customerModels.Add(customerModel);
            }

            OrderAddWindow orderAddWindow = new OrderAddWindow();

            OrderAddViewModel orderAddViewModel = new OrderAddViewModel
            {
                CurrentOrder = orderViewModel.CurrentOrder,
                CurrentWindow = orderAddWindow,
                Customers = customerModels
            };

            orderAddWindow.DataContext = orderAddViewModel;
            orderAddWindow.WindowStyle = System.Windows.WindowStyle.None;
            orderAddWindow.AllowsTransparency = true;
            orderAddWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            orderAddWindow.ShowDialog();

            List<Order> orders = DB.OrderRepository.Get();
            List<OrderModel> orderModels = new List<OrderModel>();
            OrderMapper orderMapper = new OrderMapper();

            for (int i = 0; i < orders.Count; i++)
            {
                Order order = orders[i];

                OrderModel orderModel = orderMapper.Map(order);

                orderModels.Add(orderModel);
            }

            Enumeration.Enumerate(orderModels);

            orderViewModel.AllOrders = orderModels;
            orderViewModel.Orders = new ObservableCollection<OrderModel>(orderModels);
            orderViewModel.CurrentOrder = new OrderModel();
        }
    }
}
