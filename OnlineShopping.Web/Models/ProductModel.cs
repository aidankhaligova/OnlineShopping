
using Microsoft.AspNetCore.Mvc.Rendering;
using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Models
{
    public class ProductModel : BaseModel
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public CategoryModel Category { get; set; }
        public List<SelectListItem> Categories;
        public ProductModel Clone()
        {
            ProductModel cloneModel = new ProductModel
            {
                Name = Name,
                No = No,
                Id = Id,
                Price = Price,
                Quantity = Quantity,
                Category = Category
            };

            return cloneModel;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
