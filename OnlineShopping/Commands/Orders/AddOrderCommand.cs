using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.Commands.Orders
{
    public class AddOrderCommand : BaseCommand
    {
        private readonly OrderAddViewModel orderAddViewModel;
        public AddOrderCommand(OrderAddViewModel orderAddViewModel)
        {
            this.orderAddViewModel = orderAddViewModel;
        }
        public override void Execute(object parameter)
        {
            // TODO: Step1. Validate 
            OrderMapper categoryMapper = new OrderMapper();
            Order category = categoryMapper.Map(orderAddViewModel.CurrentOrder);
            category.Creator = Kernel.CurrentUser;

            if (category.Id != 0)
            {
                DB.OrderRepository.Update(category);
            }
            else
            {
                DB.OrderRepository.Add(category);
            }

            MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            orderAddViewModel.CurrentWindow.Close();
        }
    }
}
