using OnlineShopping.Commands.Employees;
using OnlineShopping.Models;
using OnlineShopping.Views.SmallWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels.SmallWindows
{
    public class EmployeeAddViewModel : BaseViewModel
    {
        private EmployeeModel currentEmployee = new EmployeeModel();
        public EmployeeModel CurrentEmployee
        {
            get => currentEmployee;
            set
            {
                currentEmployee = value;
                OnPropertyChanged(nameof(CurrentEmployee));
            }
        }
        public EmployeeModel EditedEmployee { get; set; }
        public AddEmployeeCommand Add => new AddEmployeeCommand(this);

        public EmployeeAddWindow CurrentWindow;
    }
}
