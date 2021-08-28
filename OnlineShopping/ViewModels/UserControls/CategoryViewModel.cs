using OnlineShopping.Commands.Categories;
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
    public class CategoryViewModel : BaseControlViewModel
    {
        public override string Header => "Categories";

        public CategoryModel categoryModel = new CategoryModel();

        private CategoryModel currentCategory = new CategoryModel();
        public CategoryModel CurrentCategory
        {
            get => currentCategory;
            set
            {
                currentCategory = value;
                OnPropertyChanged(nameof(CurrentCategory));
            }
        }
        private CategoryModel selectedCategory;
        public CategoryModel SelectedCategory
        {
            get => selectedCategory;
            set
            {
                selectedCategory = value;
                OnPropertyChanged(nameof(SelectedCategory));

                CurrentCategory = SelectedCategory?.Clone();

                if (SelectedCategory != null)
                {
                    DeleteVisibility = Visibility.Visible;
                    SaveVisibility = Visibility.Hidden;
                }
            }
        }
        private ObservableCollection<CategoryModel> categories;
        public ObservableCollection<CategoryModel> Categories
        {
            get => categories;
            set
            {
                categories = value;
                OnPropertyChanged(nameof(Categories));
            }
        }

        private List<CategoryModel> allCategories;
        public List<CategoryModel> AllCategories
        {
            get => allCategories;
            set
            {
                allCategories = value;
                OnPropertyChanged(nameof(AllCategories));
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
        public void UpdateDataFiltered()
        {
            IEnumerable<CategoryModel> filteredCategories = null;

            if (string.IsNullOrWhiteSpace(SearchText))
            {
                filteredCategories = AllCategories;
            }
            else
            {
                string lowerSearchText = SearchText.ToLower();

                filteredCategories = AllCategories.Where(x =>
                        x.Name.ToLower().Contains(lowerSearchText));
            }

            Categories.Clear();

            foreach (var item in filteredCategories)
            {
                Categories.Add(item);
            }
            
            SaveVisibility = Visibility.Visible;
            DeleteVisibility = Visibility.Collapsed;
            CurrentCategory = new CategoryModel();
        }
        public OpenCategoryAddWindowCommand Save => new OpenCategoryAddWindowCommand(this);
        public DeleteCategoryCommand Delete => new DeleteCategoryCommand(this);
        public ExportToExcelCategoriesCommand ExportToExcel => new ExportToExcelCategoriesCommand(this);
    }
}
