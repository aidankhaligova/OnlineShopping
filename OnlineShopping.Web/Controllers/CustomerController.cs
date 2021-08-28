using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShopping.Core.Domains.Abstract;
using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Web.Helpers;
using OnlineShopping.Web.Mappers;
using OnlineShopping.Web.Models;
using OnlineShopping.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Controllers
{
    public class CustomerController : BaseController
    {
        public CustomerController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager) { }
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];

            List<Customer> customers = DB.CustomerRepository.Get();

            ViewModel<CustomerModel> viewModel = new ViewModel<CustomerModel>();

            CustomerMapper customerMapper = new CustomerMapper();

            foreach (var customer in customers)
            {
                var customerModel = customerMapper.Map(customer);
                viewModel.Models.Add(customerModel);
            }

            Enumeration<CustomerModel>.Enumerate(viewModel.Models);

            return View(viewModel);
        }
        [HttpGet]
        public IActionResult GetCustomer()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SaveCustomer(int id)
        {
            if (id != 0)
            {
                Customer customer = DB.CustomerRepository.Get(id);

                if (customer == null)
                    return Content("Customer not found");

                CustomerMapper mapper = new CustomerMapper();
                CustomerModel model = mapper.Map(customer);

                return View(model);
            }

            return View(new CustomerModel());
        }
        [HttpPost]
        public IActionResult SaveCustomer(CustomerModel customerModel)
        {
            if (ModelState.IsValid == false)
            {
                return Content("Model is invalid");
            }
            CustomerMapper mapper = new CustomerMapper();
            Customer customer = mapper.Map(customerModel);
            customer.Creator = CurrentUser;
            if (customer.Id != 0)
                DB.CustomerRepository.Update(customer);
            else
                DB.CustomerRepository.Add(customer);

            TempData["Message"] = "Saved successfully";

            return RedirectToAction("Index");
        }
        [HttpPost]
        public IActionResult Delete(ViewModel<CustomerModel> viewModel)
        {
            Customer customer = DB.CustomerRepository.Get(viewModel.DeletedId);

            if (customer == null)
                return Content("Customer not found ");

            customer.Creator = CurrentUser;
            customer.IsDeleted = true;
            customer.LastModified = DateTime.Now;

            DB.CustomerRepository.Update(customer);

            return RedirectToAction("Index");
        }
    }
}
