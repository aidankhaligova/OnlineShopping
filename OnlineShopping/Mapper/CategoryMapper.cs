using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Mapper
{
    public class CategoryMapper : BaseMapper<Category, CategoryModel>
    {
        public override Category Map(CategoryModel categoryModel)
        {
            if (categoryModel == null)
                return null;

            Category category = new Category();
            category.Id = categoryModel.Id;
            category.Name = categoryModel.Name;
            return category;
        }

        public override CategoryModel Map(Category category)
        {
            if (category == null)
                return null;

            CategoryModel categoryModel = new CategoryModel();
            categoryModel.Id = category.Id;
            categoryModel.Name = category.Name;
            return categoryModel;
        }
    }
}
