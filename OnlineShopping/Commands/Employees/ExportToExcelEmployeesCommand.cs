using OnlineShopping.Helpers;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Employees
{
    public class ExportToExcelEmployeesCommand : BaseEmployeeCommand
    {
        public ExportToExcelEmployeesCommand(EmployeeViewModel employeeViewModel) : base(employeeViewModel) { }
        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(employeeViewModel.Employees);
        }
    }
}
