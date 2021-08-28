using OnlineShopping.Commands.Customers;
using OnlineShopping.Models;
using OnlineShopping.Views.SmallWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels.SmallWindows
{
    public class CustomerAddViewModel : BaseViewModel
    {
        private CustomerModel currentCustomer = new CustomerModel();
        public CustomerModel CurrentCustomer
        {
            get => currentCustomer;
            set
            {
                currentCustomer = value;
                OnPropertyChanged(nameof(CurrentCustomer));
            }
        }
        public CustomerModel EditedCustomer { get; set; }
        public AddCustomerCommand Add => new AddCustomerCommand(this);
        public CustomerAddWindow CurrentWindow;
    }
}
