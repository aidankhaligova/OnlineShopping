using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Orders
{
    public abstract class BaseOrderCommand:BaseCommand
    {
        protected readonly OrderViewModel orderViewModel;
        public BaseOrderCommand(OrderViewModel orderViewModel)
        {
            this.orderViewModel = orderViewModel;
        }
    }
}
