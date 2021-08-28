using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.Commands.Employees
{
    public class DeleteEmployeeCommand : BaseEmployeeCommand
    {
        public DeleteEmployeeCommand(EmployeeViewModel employeeViewModel) : base(employeeViewModel)
        {
        }
        public override void Execute(object parameter)
        {
            SureDialogViewModel sureViewModel = new SureDialogViewModel
            {
                DialogText = UIMessages.DeleteSureMessage
            };

            SureDialog dialog = new SureDialog
            {
                DataContext = sureViewModel
            };
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                EmployeeMapper mapper = new EmployeeMapper();

                Employee employee = mapper.Map(employeeViewModel.CurrentEmployee);
                employee.IsDeleted = true;
                employee.Creator = Kernel.CurrentUser;

                DB.EmployeeRepository.Update(employee);

                int no = employeeViewModel.SelectedEmployee.No;

                employeeViewModel.Employees.Remove(employeeViewModel.SelectedEmployee);

                List<EmployeeModel> employeeModelList = employeeViewModel.Employees.ToList();
                Enumeration.Enumerate(employeeModelList, no - 1);

                employeeViewModel.AllEmployees = employeeModelList;
                employeeViewModel.UpdateDataFiltered();

                employeeViewModel.SelectedEmployee = null;
                employeeViewModel.CurrentEmployee = new EmployeeModel();

                MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
