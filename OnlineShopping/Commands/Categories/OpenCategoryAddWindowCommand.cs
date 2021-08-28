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

namespace OnlineShopping.Commands.Categories
{
    public class OpenCategoryAddWindowCommand : BaseCategoryCommand
    {
        public OpenCategoryAddWindowCommand(CategoryViewModel viewModel) : base(viewModel)
        {
        }
        public override void Execute(object parameter)
        {
            CategoryAddWindow categoryAddWindow = new CategoryAddWindow();

            CategoryAddViewModel categoryAddViewModel = new CategoryAddViewModel
            {
                CurrentCategory = categoryViewModel.CurrentCategory,
                CurrentWindow = categoryAddWindow
            };

            categoryAddWindow.DataContext = categoryAddViewModel;
            categoryAddWindow.WindowStyle = System.Windows.WindowStyle.None;
            categoryAddWindow.AllowsTransparency = true;
            categoryAddWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            categoryAddWindow.ShowDialog();

            List<Category> categories = DB.CategoryRepository.Get();
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            CategoryMapper categoryMapper = new CategoryMapper();

            for (int i = 0; i < categories.Count; i++)
            {
                Category category = categories[i];

                CategoryModel categoryModel = categoryMapper.Map(category);

                categoryModels.Add(categoryModel);
            }

            Enumeration.Enumerate(categoryModels);

            categoryViewModel.AllCategories = categoryModels;
            categoryViewModel.Categories = new ObservableCollection<CategoryModel>(categoryModels);

            categoryViewModel.CurrentCategory = new CategoryModel();
        }
    }
}
