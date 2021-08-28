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
using System.Windows;

namespace OnlineShopping.Commands.MainPage
{
    public class OpenProductsCommand : BaseCommand
    {
        private readonly MainViewModel mainViewModel;
        public OpenProductsCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }
        public override void Execute(object parameter)
        {
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

            ProductViewModel productViewModel = new ProductViewModel
            {
                AllProducts = productModels,
                Products = new ObservableCollection<ProductModel>(productModels)
            };

            ProductsControl productsControl = new ProductsControl
            {
                DataContext = productViewModel
            };

            MainWindow mainWindow = (MainWindow)mainViewModel.Window;
            mainWindow.GrdCenter.Children.Clear();
            mainWindow.GrdCenter.Children.Add(productsControl);

            if(productViewModel.CurrentProduct.Name!=null)
            {
                productViewModel.DeleteVisibility = Visibility.Visible;
            }
        }
    }
}
