using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace OnlineShopping.Commands.Orders
{
    public class DeleteOrderCommand : BaseOrderCommand
    {
        public DeleteOrderCommand(OrderViewModel orderViewModel): base(orderViewModel) { }
        public override void Execute(object parameter)
        {
            SureDialogViewModel sureViewModel = new SureDialogViewModel();
            sureViewModel.DialogText = UIMessages.DeleteSureMessage;

            SureDialog dialog = new SureDialog();
            dialog.DataContext = sureViewModel;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                OrderMapper mapper = new OrderMapper();

                Order order = mapper.Map(orderViewModel.CurrentOrder);
                order.IsDeleted = true;
                order.Creator = Kernel.CurrentUser;

                DB.OrderRepository.Update(order);

                int no = orderViewModel.SelectedOrder.No;

                orderViewModel.Orders.Remove(orderViewModel.SelectedOrder);

                List<OrderModel> orderModelList = orderViewModel.Orders.ToList();
                Enumeration.Enumerate(orderModelList, no - 1);

                orderViewModel.AllOrders = orderModelList;
                orderViewModel.UpdateDataFiltered();

                orderViewModel.SelectedOrder = null;
                orderViewModel.CurrentOrder = new OrderModel();

                MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
