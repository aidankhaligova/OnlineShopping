using OnlineShopping.Helpers;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Orders
{
    public class ExportToExcelOrderCommand : BaseOrderCommand
    {
        public ExportToExcelOrderCommand(OrderViewModel orderViewModel) : base(orderViewModel) { }
        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(orderViewModel.Orders);
        }
    }
}
