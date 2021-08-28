using OnlineShopping.Helpers;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Customers
{
    public class ExportToExcelCustomersCommand : BaseCustomerCommand
    {
        public ExportToExcelCustomersCommand(CustomerViewModel customerViewModel) : base(customerViewModel) { }
        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(customerViewModel.Customers);
        }
    }
}
