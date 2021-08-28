using OnlineShopping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class CategoryModel : BaseModel
    {
        [Export(Name ="Kateqoriyalar")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
        
        public CategoryModel Clone()
        {
            CategoryModel cloneModel = new CategoryModel();

            cloneModel.Name = Name;
            cloneModel.No = No;
            cloneModel.Id = Id;
          

            return cloneModel;
        }
    }
}
