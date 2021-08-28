
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Products
{
    public abstract class BaseProductCommand:BaseCommand
    {
        protected readonly ProductViewModel productViewModel;
        public BaseProductCommand(ProductViewModel productViewModel)
        {
            this.productViewModel = productViewModel;
        }
    }
}
