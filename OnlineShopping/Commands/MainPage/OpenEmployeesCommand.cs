using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.UserControls;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.MainPage
{
    public class OpenEmployeesCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenEmployeesCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public override void Execute(object parameter)
        {
            List<Employee> employees = DB.EmployeeRepository.Get();
            List<EmployeeModel> employeeModels = new List<EmployeeModel>();
            EmployeeMapper employeeMapper = new EmployeeMapper();


            for (int i = 0; i < employees.Count; i++)
            {
                Employee employee = employees[i];

                EmployeeModel employeeModel = employeeMapper.Map(employee);
                employeeModel.No = i + 1;

                employeeModels.Add(employeeModel);
            }

            Enumeration.Enumerate(employeeModels);

            EmployeeViewModel employeeViewModel = new EmployeeViewModel();
            employeeViewModel.AllEmployees = employeeModels;
            employeeViewModel.Employees = new ObservableCollection<EmployeeModel>(employeeModels);

            EmployeesControl employeesControl = new EmployeesControl();
            employeesControl.DataContext = employeeViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(employeesControl);
        }
    }
}
