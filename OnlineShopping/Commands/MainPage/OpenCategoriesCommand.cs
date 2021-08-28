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
    public class OpenCategoriesCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenCategoriesCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
            List<Category> categories = DB.CategoryRepository.Get();
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            CategoryMapper categoryMapper = new CategoryMapper();

            for (int i = 0; i < categories.Count; i++)
            {
                Category category = categories[i];

                CategoryModel categoryModel = categoryMapper.Map(category);
                categoryModel.No = i + 1;

                categoryModels.Add(categoryModel);
            }

            Enumeration.Enumerate(categoryModels);

            CategoryViewModel categoryViewModel = new CategoryViewModel();
            categoryViewModel.AllCategories = categoryModels;
            categoryViewModel.Categories = new ObservableCollection<CategoryModel>(categoryModels);

            CategoriesControl categoriesControl = new CategoriesControl();
            categoriesControl.DataContext = categoryViewModel;

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(categoriesControl);

        }
    }
}
