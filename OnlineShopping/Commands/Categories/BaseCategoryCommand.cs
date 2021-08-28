using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Categories
{
    public abstract class BaseCategoryCommand:BaseCommand
    {
        protected readonly CategoryViewModel categoryViewModel;
        public BaseCategoryCommand(CategoryViewModel categoryViewModel)
        {
            this.categoryViewModel = categoryViewModel;
        }
    }
}
