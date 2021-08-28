using OnlineShopping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class OrderModel : BaseModel
    {
        [Export(Name ="Musteri")]
        public CustomerModel Customer { get; set; }
        [Export(Name = "Unvan")]
        public string Address { get; set; }
        [Export(Name = "Qeyd")]
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
