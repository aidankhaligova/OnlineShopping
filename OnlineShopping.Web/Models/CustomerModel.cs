
using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Models
{
    public class CustomerModel:BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public CustomerModel Clone()
        {
            CustomerModel cloneModel = new CustomerModel
            {
                Name = Name,
                No = No,
                Id = Id,
                Surname = Surname,
                Address = Address,
                Phone = Phone
            };

            return cloneModel;
        }
        public override string ToString()
        {
            return Name;
        }
    }
}
