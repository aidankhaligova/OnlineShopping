using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Entities
{
    public class Order : BaseEntity
    {
        public Customer Customer { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        
        // not map in db
        public List<OrderDetail> Details { get; set; }
    }
}
