
using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Models
{
    public class EmployeeModel:BaseModel
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Pin { get; set; }
        public double Salary { get; set; }
        public string PhoneNumber { get; set; }
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
