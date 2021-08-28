using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Mapper
{
    public class CustomerMapper : BaseMapper<Customer, CustomerModel>
    {
        public override Customer Map(CustomerModel customerModel)
        {
            Customer customer = new Customer();
            customer.Id = customerModel.Id;
            customer.Name = customerModel.Name;
            customer.Surname = customerModel.Surname;
            customer.PhoneNumber = customerModel.Phone;
            customer.Address = customerModel.Address;
            return customer;

        }

        public override CustomerModel Map(Customer customer)
        {
            CustomerModel customerModel = new CustomerModel();
            customerModel.Id = customer.Id;
            customerModel.Name = customer.Name;
            customerModel.Surname = customer.Surname;
            customerModel.Phone = customer.PhoneNumber;
            customerModel.Address = customer.Address;

            return customerModel;
        }
    }
}
