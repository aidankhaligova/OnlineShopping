using OnlineShopping.Commands.MainPage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels
{
    public class MainViewModel : BaseWindowViewModel
    {
        public OpenProductsCommand OpenProducts => new OpenProductsCommand(this);
        public OpenCustomersCommand OpenCustomers => new OpenCustomersCommand(this);
        public OpenEmployeesCommand OpenEmployees => new OpenEmployeesCommand(this);
        public OpenCategoriesCommand OpenCategories => new OpenCategoriesCommand(this);
        public OpenOrdersCommand OpenOrders => new OpenOrdersCommand(this);
    }
}
