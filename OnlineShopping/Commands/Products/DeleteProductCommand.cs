using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels;
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using OnlineShopping.Views.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.Commands.Products
{
    public class DeleteProductCommand : BaseProductCommand
    {
        public DeleteProductCommand(ProductViewModel productViewModel) : base(productViewModel) { }
        public override void Execute(object parameter)
        {
            SureDialogViewModel sureViewModel = new SureDialogViewModel();
            sureViewModel.DialogText = UIMessages.DeleteSureMessage;

            SureDialog dialog = new SureDialog();
            dialog.DataContext = sureViewModel;
            dialog.ShowDialog();
            if (dialog.DialogResult == true)
            {
                ProductMapper mapper = new ProductMapper();

                Product product = mapper.Map(productViewModel.CurrentProduct);
                product.IsDeleted = true;
                product.Creator = Kernel.CurrentUser;

                DB.ProductRepository.Update(product);

                int no = productViewModel.SelectedProduct.No;

                productViewModel.Products.Remove(productViewModel.SelectedProduct);

                List<ProductModel> productModelList = productViewModel.Products.ToList();
                Enumeration.Enumerate(productModelList, no - 1);

                productViewModel.AllProducts = productModelList;
                productViewModel.UpdateDataFiltered();

                productViewModel.SelectedProduct = null;
                productViewModel.CurrentProduct = new ProductModel();

                MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}

