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

namespace OnlineShopping.Commands.Categories
{
    public class AddCategoryCommand : BaseCommand
    {
        private readonly CategoryAddViewModel categoryAddViewModel;
        public AddCategoryCommand(CategoryAddViewModel categoryAddViewModel)
        {
            this.categoryAddViewModel = categoryAddViewModel;
        }
        public override void Execute(object parameter)
        {
            // TODO: Step1. Validate Model-xeta mesajlarini cixar
            CategoryMapper categoryMapper = new CategoryMapper();
            Category category = categoryMapper.Map(categoryAddViewModel.CurrentCategory);
            category.Creator = Kernel.CurrentUser;

            if (category.Id!=0)
            {
                DB.CategoryRepository.Update(category);
            }
            else
            {
                DB.CategoryRepository.Add(category);
            }

            MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            categoryAddViewModel.CurrentWindow.Close();
        }
    }
}
