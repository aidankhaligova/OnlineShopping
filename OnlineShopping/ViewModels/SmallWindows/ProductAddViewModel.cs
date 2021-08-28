using OnlineShopping.Commands.Products;
using OnlineShopping.Models;
using OnlineShopping.Views.SmallWindows;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels.SmallWindows
{
    public class ProductAddViewModel : BaseViewModel
    {
        private ProductModel currentProduct = new ProductModel();
        public ProductModel CurrentProduct
        {
            get => currentProduct;
            set
            {
                currentProduct = value;
                OnPropertyChanged(nameof(CurrentProduct));
            }
        }

        private List<CategoryModel> categories;
        public List<CategoryModel> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }
        public ProductModel EditedProduct { get; set; }
        public AddProductCommand Add => new AddProductCommand(this);

        public ProductAddWindow CurrentWindow;
    }
}
