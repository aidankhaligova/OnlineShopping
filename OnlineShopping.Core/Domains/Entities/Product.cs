using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Entities
{
    public class Product: BaseEntity
    {
        public string Name { get; set; }
        public double Quantity { get; set; }
        public double Price { get; set; }
        public Category Category { get; set; }
    }
}
