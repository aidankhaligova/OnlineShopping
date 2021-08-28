using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Employees
{
    public abstract class BaseEmployeeCommand:BaseCommand
    {
        protected readonly EmployeeViewModel employeeViewModel;
        public BaseEmployeeCommand(EmployeeViewModel employeeViewModel)
        {
            this.employeeViewModel = employeeViewModel;
        }
    }
}
