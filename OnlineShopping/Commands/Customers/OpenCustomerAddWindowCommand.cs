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
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Customers
{
    public class OpenCustomerAddWindowCommand : BaseCustomerCommand
    {
        public OpenCustomerAddWindowCommand(CustomerViewModel customerViewModel) : base(customerViewModel) { }
        public override void Execute(object parameter)
        {
            CustomerAddWindow customerAddWindow = new CustomerAddWindow();

            CustomerAddViewModel customerAddViewModel = new CustomerAddViewModel();
            customerAddViewModel.CurrentCustomer = customerViewModel.CurrentCustomer;
            customerAddViewModel.CurrentWindow = customerAddWindow;

            customerAddWindow.DataContext = customerAddViewModel;
            customerAddWindow.WindowStyle = System.Windows.WindowStyle.None;
            customerAddWindow.AllowsTransparency = true;
            customerAddWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            customerAddWindow.ShowDialog();

            // Refresh Customers list
            List<Customer> customers = DB.CustomerRepository.Get();
            List<CustomerModel> customerModels = new List<CustomerModel>();
            CustomerMapper customerMapper = new CustomerMapper();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer customer = customers[i];

                CustomerModel customerModel = customerMapper.Map(customer);

                customerModels.Add(customerModel);
            }

            Enumeration.Enumerate(customerModels);

            customerViewModel.AllCustomers = customerModels;
            customerViewModel.Customers = new ObservableCollection<CustomerModel>(customerModels);

            customerViewModel.CurrentCustomer = new CustomerModel();
        }
    }
}
