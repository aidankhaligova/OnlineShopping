using OnlineShopping.Commands.Products;
using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace OnlineShopping.ViewModels.UserControls
{
    public class ProductViewModel : BaseControlViewModel
    {
        public override string Header => "Products";
        public ProductViewModel() { }

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
        private ProductModel selectedProduct;
        public ProductModel SelectedProduct
        {
            get => selectedProduct;
            set
            {
                selectedProduct = value;
                OnPropertyChanged(nameof(SelectedProduct));

                CurrentProduct = SelectedProduct?.Clone();

                if (SelectedProduct != null)
                {
                    DeleteVisibility =Visibility.Visible;
                    SaveVisibility = Visibility.Hidden;
                }
            }
        }
        private ObservableCollection<ProductModel> products;
        public ObservableCollection<ProductModel> Products
        {
            get => products;
            set
            {
                products = value;
                OnPropertyChanged(nameof(Products));
            }
        }

        private List<ProductModel> allProducts;
        public List<ProductModel> AllProducts
        {
            get => allProducts;
            set
            {
                allProducts = value;
                OnPropertyChanged(nameof(AllProducts));
            }
        }
        private string searchText;
        public string SearchText
        {
            get => searchText;
            set
            {
                searchText = value;
                OnPropertyChanged(nameof(SearchText));
                UpdateDataFiltered();
            }
        }
        private Visibility saveVisibility = Visibility.Visible;
        public Visibility SaveVisibility
        {
            get => saveVisibility;
            set
            {
                saveVisibility = value;
                OnPropertyChanged(nameof(SaveVisibility));
            }
        }
        private Visibility deleteVisibility = Visibility.Collapsed;
        public Visibility DeleteVisibility
        {
            get => deleteVisibility;
            set
            {
                deleteVisibility = value;
                OnPropertyChanged(nameof(DeleteVisibility));
            }
        }
        public void UpdateDataFiltered()
        {
            IEnumerable<ProductModel> filteredProducts = null;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredProducts = AllProducts;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                filteredProducts = AllProducts.Where(x =>
                        x.Name.ToLower().Contains(lowerSearchText) ||
                        x.Price.ToString().Contains(lowerSearchText) ||
                        x.Quantity.ToString().Contains(lowerSearchText) ||
                        x.Category.ToString().Contains(lowerSearchText));
            }
            
            Products.Clear();

            foreach (var item in filteredProducts)
            {
                Products.Add(item);
            }

            CurrentProduct = new ProductModel();
            SaveVisibility = Visibility.Visible;
            DeleteVisibility = Visibility.Collapsed;
        }
        public OpenProductAddWindowCommand Save => new OpenProductAddWindowCommand(this);
        public DeleteProductCommand Delete => new DeleteProductCommand(this);
        public ExportToExcelProductsCommand ExportToExcel => new ExportToExcelProductsCommand(this);
    }
}
