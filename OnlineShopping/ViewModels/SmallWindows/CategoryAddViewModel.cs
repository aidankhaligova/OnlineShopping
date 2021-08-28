using OnlineShopping.Commands.Categories;
using OnlineShopping.Models;
using OnlineShopping.Views.SmallWindows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.ViewModels.SmallWindows
{
    public class CategoryAddViewModel:BaseViewModel
    {
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
       

        public CategoryModel EditedCategory { get; set; }

        public AddCategoryCommand Add => new AddCategoryCommand(this);
        public CategoryAddWindow CurrentWindow;
    }
}
