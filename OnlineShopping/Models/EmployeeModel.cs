using OnlineShopping.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Models
{
    public class EmployeeModel:BaseModel
    {
        [Export(Name ="Adi")]
        public string Name { get; set; }
        [Export(Name = "Soyadi")]
        public string Surname { get; set; }
        [Export(Name = "FIN")]
        public string Pin { get; set; }
        [Export(Name = "Maas")]
        public double Salary { get; set; }
        [Export(Name = "Telefon")]
        public string PhoneNumber { get; set; }
        [Export(Name = "Kuryerdir?")]
        public bool IsCourier { get; set; }
        public EmployeeModel Clone()
        {
            EmployeeModel cloneModel = new EmployeeModel
            {
                Name = Name,
                Surname = Surname,
                No = No,
                Id = Id,
                Pin = Pin,
                Salary = Salary,
                PhoneNumber = PhoneNumber,
                IsCourier = IsCourier
            };
            return cloneModel;
        }
    }
}
