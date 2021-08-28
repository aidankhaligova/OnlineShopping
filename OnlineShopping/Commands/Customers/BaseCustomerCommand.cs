using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Customers
{
    public abstract class BaseCustomerCommand : BaseCommand
    {
        protected readonly CustomerViewModel customerViewModel;
        public BaseCustomerCommand(CustomerViewModel customerViewModel)
        {
            this.customerViewModel = customerViewModel;
        }
    }
}
