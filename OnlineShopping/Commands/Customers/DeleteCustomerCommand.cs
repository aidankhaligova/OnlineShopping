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
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.Commands.Customers
{
    public class DeleteCustomerCommand : BaseCustomerCommand
    {
        public DeleteCustomerCommand(CustomerViewModel customerViewModel) : base(customerViewModel) { }
        public override void Execute(object parameter)
        {
            SureDialogViewModel sureViewModel = new SureDialogViewModel
            {
                DialogText = UIMessages.DeleteSureMessage
            };

            SureDialog dialog = new SureDialog();
            dialog.DataContext = sureViewModel;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                CustomerMapper mapper = new CustomerMapper();

                Customer customer = mapper.Map(customerViewModel.CurrentCustomer);
                customer.IsDeleted = true;
                customer.Creator = Kernel.CurrentUser;

                DB.CustomerRepository.Update(customer);

                int no = customerViewModel.SelectedCustomer.No;


                customerViewModel.Customers.Remove(customerViewModel.SelectedCustomer);

                List<CustomerModel> modelList = customerViewModel.Customers.ToList();
                Enumeration.Enumerate(modelList, no - 1);

                customerViewModel.AllCustomers = modelList;
                customerViewModel.UpdateDataFiltered();

                customerViewModel.SelectedCustomer = null;
                customerViewModel.CurrentCustomer = new CustomerModel();

                MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
