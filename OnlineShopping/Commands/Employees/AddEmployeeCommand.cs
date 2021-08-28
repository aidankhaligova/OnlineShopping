using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.Commands.Employees
{
    public class AddEmployeeCommand : BaseCommand
    {
        private readonly EmployeeAddViewModel employeeAddViewModel;
        public AddEmployeeCommand(EmployeeAddViewModel employeeAddViewModel)
        {
            this.employeeAddViewModel = employeeAddViewModel;
        }
        public override void Execute(object parameter)
        {
            //TODO: Validate
            EmployeeMapper employeeMapper = new EmployeeMapper();
            Employee employee = employeeMapper.Map(employeeAddViewModel.CurrentEmployee);
            employee.Creator = Kernel.CurrentUser;

            if(employee.Id!=0)
            {
                DB.EmployeeRepository.Update(employee);
            }
            else
            {
                DB.EmployeeRepository.Add(employee);
            }
            
            
            MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            employeeAddViewModel.CurrentWindow.Close();
        }
    }
}
