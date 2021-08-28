using OnlineShopping.Core;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Helpers;
using OnlineShopping.Mapper;
using OnlineShopping.Models;
using OnlineShopping.ViewModels.SmallWindows;
using OnlineShopping.ViewModels.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.Commands.Products
{
    public class AddProductCommand : BaseCommand
    {
        private readonly ProductAddViewModel productAddViewModel;
        public AddProductCommand(ProductAddViewModel productAddViewModel)
        {
            this.productAddViewModel = productAddViewModel;
        }

        public override void Execute(object parameter)
        {
            // TODO: Validate
            ProductMapper productMapper = new ProductMapper();
            Product product = productMapper.Map(productAddViewModel.CurrentProduct);
            product.Creator = Kernel.CurrentUser;
            if(product.Id!=0)
            {
                DB.ProductRepository.Update(product);
            }
            else 
            {
                DB.ProductRepository.Add(product);
            }
           
            MessageBox.Show(UIMessages.OperationSuccessMessage, "Information", MessageBoxButton.OK, MessageBoxImage.Information);

            productAddViewModel.CurrentWindow.Close();
        }
    }
}
