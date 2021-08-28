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

namespace OnlineShopping.Commands.Categories
{
    public class DeleteCategoryCommand : BaseCategoryCommand
    { 
      public DeleteCategoryCommand(CategoryViewModel categoryViewModel) : base(categoryViewModel)
      {

      }
      public override void Execute(object parameter)
      {
            SureDialogViewModel sureViewModel = new SureDialogViewModel();
            sureViewModel.DialogText = UIMessages.DeleteSureMessage;

            SureDialog dialog = new SureDialog();
            dialog.DataContext = sureViewModel;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                CategoryMapper mapper = new CategoryMapper();

                Category category = mapper.Map(categoryViewModel.CurrentCategory);
                category.IsDeleted = true;
                category.Creator = Kernel.CurrentUser;

                DB.CategoryRepository.Update(category);

                int no = categoryViewModel.SelectedCategory.No;


                categoryViewModel.Categories.Remove(categoryViewModel.SelectedCategory);

                List<CategoryModel> modelList = categoryViewModel.Categories.ToList();
                Enumeration.Enumerate(modelList, no - 1);

                categoryViewModel.AllCategories = modelList;
                categoryViewModel.UpdateDataFiltered();

                categoryViewModel.SelectedCategory = null;
                categoryViewModel.CurrentCategory = new CategoryModel();

                MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
