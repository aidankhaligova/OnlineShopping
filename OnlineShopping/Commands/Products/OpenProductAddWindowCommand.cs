using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.Components;
using OnlineShopping.Views.SmallWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Commands.Products
{
    public class OpenProductAddWindowCommand : BaseProductCommand
    {
        public OpenProductAddWindowCommand(ProductViewModel productViewModel) : base(productViewModel) { }

        public override void Execute(object parameter)
        {
            //OrderAddViewModel addViewModel = new OrderAddViewModel();
            //OrderAddWindow addWindow = new OrderAddWindow();

            //addViewModel.DetailPanel = addWindow.DetailPanel;
            //addViewModel.DetailPanel.Children.Add(new SingleOrderDetailControl());
            //addWindow.DataContext = addViewModel;

            //addWindow.ShowDialog();
            //return;

            ProductAddWindow productAddWindow = new ProductAddWindow();

            ProductAddViewModel productAddViewModel = new ProductAddViewModel
            {
                CurrentProduct = productViewModel.CurrentProduct,
                CurrentWindow = productAddWindow
            };

            #region Category-for Combobox

            List<Category> categories = DB.CategoryRepository.Get();
            List<CategoryModel> categoryModels = new List<CategoryModel>();
            CategoryMapper categoryMapper = new CategoryMapper();

            for (int i = 0; i < categories.Count; i++)
            {
                Category category = categories[i];

                CategoryModel categoryModel = categoryMapper.Map(category);

                categoryModels.Add(categoryModel);
            }

            productAddViewModel.Categories = categoryModels;

            #endregion

            productAddWindow.DataContext = productAddViewModel;
            productAddWindow.WindowStyle = System.Windows.WindowStyle.None;
            productAddWindow.AllowsTransparency =true;
            productAddWindow.WindowStartupLocation = System.Windows.WindowStartupLocation.CenterScreen;
            productAddWindow.ShowDialog();

            // Refresh products list
            List<Product> products = DB.ProductRepository.Get();
            List<ProductModel> productModels = new List<ProductModel>();
            ProductMapper productMapper = new ProductMapper();

            for (int i = 0; i < products.Count; i++)
            {
                Product product = products[i];

                ProductModel productModel = productMapper.Map(product);

                productModels.Add(productModel);
            }

            Enumeration.Enumerate(productModels);

            productViewModel.AllProducts = productModels;
            productViewModel.Products = new ObservableCollection<ProductModel>(productModels);

            productViewModel.CurrentProduct = new ProductModel();
        }
    }
}
