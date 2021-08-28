using OnlineShopping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class CustomerModel:BaseModel
    {
        [Export(Name ="Musteri adi")]
        public string Name { get; set; }

        [Export(Name = "Musteri soyadi")]
        public string Surname { get; set; }

        [Export(Name = "Musteri adresi")]
        public string Address { get; set; }

        [Export(Name = "Musteri telefonu")]
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
