using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Entities
{
    public class Employee : BaseEntity
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pin { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsCourier { get; set; }

    }
}
