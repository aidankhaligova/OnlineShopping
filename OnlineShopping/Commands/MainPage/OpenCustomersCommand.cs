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
    public class OpenCustomersCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenCustomersCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            List<Customer> customers = DB.CustomerRepository.Get();
            List<CustomerModel> customerModels = new List<CustomerModel>();
            CustomerMapper customerMapper = new CustomerMapper();

            for (int i = 0; i < customers.Count; i++)
            {
                Customer customer = customers[i];

                CustomerModel customerModel = customerMapper.Map(customer);
                customerModel.No = i + 1;

                customerModels.Add(customerModel);
            }

            Enumeration.Enumerate(customerModels);

            CustomerViewModel customerViewModel = new CustomerViewModel();
            customerViewModel.AllCustomers = customerModels;
            customerViewModel.Customers = new ObservableCollection<CustomerModel>(customerModels);

            CustomersControl customersControl = new CustomersControl();
            customersControl.DataContext = customerViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(customersControl);
        }
    }
}
