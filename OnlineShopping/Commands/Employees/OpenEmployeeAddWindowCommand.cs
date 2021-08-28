using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.SmallWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Employees
{
    public class OpenEmployeeAddWindowCommand : BaseEmployeeCommand
    {
        public OpenEmployeeAddWindowCommand(EmployeeViewModel employeeViewModel) : base(employeeViewModel) { }
        public override void Execute(object parameter)
        {
            EmployeeAddWindow employeeAddWindow = new EmployeeAddWindow();

            EmployeeAddViewModel employeeAddViewModel = new EmployeeAddViewModel
            {
                CurrentEmployee = employeeViewModel.CurrentEmployee,
                CurrentWindow = employeeAddWindow
            };

            employeeAddWindow.DataContext = employeeAddViewModel;
            employeeAddWindow.WindowStyle = System.Windows.WindowStyle.None;
            employeeAddWindow.AllowsTransparency = true;
            employeeAddWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            employeeAddWindow.ShowDialog();

            List<Employee> employees = DB.EmployeeRepository.Get();
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            EmployeeMapper employeeMapper = new EmployeeMapper();

            for (int i = 0; i < employees.Count; i++)
            {
                Employee employee = employees[i];

                EmployeeModel employeeModel = employeeMapper.Map(employee);

                employeeModels.Add(employeeModel);
            }

            Enumeration.Enumerate(employeeModels);

            employeeViewModel.AllEmployees = employeeModels;
            employeeViewModel.Employees = new ObservableCollection<EmployeeModel>(employeeModels);

            employeeViewModel.CurrentEmployee = new EmployeeModel();
        }
    }
}
