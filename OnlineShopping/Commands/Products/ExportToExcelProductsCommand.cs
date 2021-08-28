using OnlineShopping.Helpers;
using OnlineShopping.Models;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Products
{
    public class ExportToExcelProductsCommand : BaseProductCommand
    {
        public ExportToExcelProductsCommand(ProductViewModel productViewModel) : base(productViewModel) { }
        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(productViewModel.Products);
        }
    }
}
