using OnlineShopping.Helpers;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Categories
{
    public class ExportToExcelCategoriesCommand : BaseCategoryCommand
    {
        public ExportToExcelCategoriesCommand(CategoryViewModel categoryViewModel) : base(categoryViewModel) { }
        public override void Execute(object parameter)
        {
            ExcelExporter.WriteToExcel(categoryViewModel.Categories);
        }
    }
}
