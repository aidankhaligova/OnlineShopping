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

namespace OnlineShopping.Commands.Customers
{
    public class AddCustomerCommand : BaseCommand
    {
        private readonly CustomerAddViewModel customerAddViewModel;
        public AddCustomerCommand(CustomerAddViewModel customerAddViewModel)
        {
            this.customerAddViewModel = customerAddViewModel;
        }
        public override void Execute(object parameter)
        {
            // TODO: Validate 
            CustomerMapper customerMapper = new CustomerMapper();
            Customer customer = customerMapper.Map(customerAddViewModel.CurrentCustomer);
            customer.Creator = Kernel.CurrentUser;
            if (customer.Id != 0)
            {
                DB.CustomerRepository.Update(customer);
            }
            else
            {
                DB.CustomerRepository.Add(customer);
            }

            MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            customerAddViewModel.CurrentWindow.Close();
        }
    }
}
