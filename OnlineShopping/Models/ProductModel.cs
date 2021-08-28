using OnlineShopping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class ProductModel : BaseModel
    {
        [Export(Name="Mehsulun adi")]
        public string Name { get; set; }

        [Export(Name ="Mehsulun sayi")]
        public double Quantity { get; set; }
        
        [Export(Name = "Mehsulun qiymeti")]
        public double Price { get; set; }
        
        [Export(Name = "Mehsulun kateqoriyasi")]
        public CategoryModel Category { get; set; }

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
