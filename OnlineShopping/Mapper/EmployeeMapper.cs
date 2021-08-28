using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Mapper
{
    public class EmployeeMapper : BaseMapper<Employee, EmployeeModel>
    {
        public override Employee Map(EmployeeModel employerModel)
        {
            Employee employer = new Employee();
            employer.Id = employerModel.Id;
            employer.Name = employerModel.Name;
            employer.Surname = employerModel.Surname;
            employer.Pin = employerModel.Pin;
            employer.Salary = employerModel.Salary;
            employer.PhoneNumber = employerModel.PhoneNumber;
            employer.IsCourier = employerModel.IsCourier;
            return employer;
        }

        public override EmployeeModel Map(Employee employer)
        {
            EmployeeModel employerModel = new EmployeeModel();
            employerModel.Id = employer.Id;
            employerModel.Name = employer.Name;
            employerModel.Surname = employer.Surname;
            employerModel.Pin = employer.Pin;
            employerModel.Salary = employer.Salary;
            employerModel.PhoneNumber = employer.PhoneNumber;
            employerModel.IsCourier = employer.IsCourier;
            return employerModel;
        }
    }
}
