
using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Models
{
    public class OrderModel : BaseModel
    {
        public CustomerModel Customer { get; set; }
        public string Address { get; set; }
        public string Note { get; set; }
        public OrderModel Clone()
        {
            OrderModel cloneModel = new OrderModel
            {
                Customer = Customer,
                No = No,
                Id = Id,
                Address = Address,
                Note = Note
            };

            return cloneModel;
        }
    }
}
