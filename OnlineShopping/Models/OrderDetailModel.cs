using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class OrderDetailModel : BaseModel
    {
        public ProductModel Product { get; set; }
        public double OrderCount { get; set; }
        public OrderModel Order { get; set; }
    }
}
