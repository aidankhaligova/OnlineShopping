using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Entities
{
    public class OrderDetail : BaseEntity
    {
        public Product Product { get; set; }
        public double OrderCount { get; set; }
        public Order Order { get; set; }
    }
}
