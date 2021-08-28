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
    public class EmployeeController : BaseController
    {
        public EmployeeController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager) { }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];
            List<Employee> employees = DB.EmployeeRepository.Get();

            ViewModel<EmployeeModel> viewModel = new ViewModel<EmployeeModel>();

            EmployeeMapper employeeMapper = new EmployeeMapper();

            foreach (var employee in employees)
            {
                var employeeModel = employeeMapper.Map(employee);
                viewModel.Models.Add(employeeModel);
            }

            Enumeration<EmployeeModel>.Enumerate(viewModel.Models);

            return View(viewModel);
        }

        //[HttpGet]
        //public IActionResult GetEmployee(int id)
        //{
        //    if (id != 0)
        //    {
        //        Employee employee = DB.EmployeeRepository.Get(id);

        //        if (employee == null)
        //            return Content("Employee not found");

        //        EmployeeMapper mapper = new EmployeeMapper();
        //        EmployeeModel model = mapper.Map(employee);

        //        return View(model);
        //    }

        //    return View(new EmployeeModel());
        //}

        [HttpGet]
        public IActionResult SaveEmployee(int id)
        {
            if (id != 0)
            {
                Employee employee = DB.EmployeeRepository.Get(id);

                if (employee == null)
                    return Content("Employee not found");

                EmployeeMapper mapper = new EmployeeMapper();
                EmployeeModel model = mapper.Map(employee);

                return View(model);
            }

            return View(new EmployeeModel());
        }

        [HttpPost]
        public IActionResult SaveEmployee(EmployeeModel employeeModel)
        {
            if (ModelState.IsValid == false)
            {
                return Content("Model is invalid");
            }

            EmployeeMapper mapper = new EmployeeMapper();
            Employee employee = mapper.Map(employeeModel);

            employee.Creator = CurrentUser;

            if (employee.Id != 0)
                DB.EmployeeRepository.Update(employee);
            else
                DB.EmployeeRepository.Add(employee);

            TempData["Message"] = "Saved successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(ViewModel<EmployeeModel> viewModel)
        {
            Employee employee = DB.EmployeeRepository.Get(viewModel.DeletedId);

            if (employee == null)
                return Content("Employee not found");

            employee.Creator = CurrentUser;
            employee.IsDeleted = true;
            employee.LastModified = DateTime.Now;

            DB.EmployeeRepository.Update(employee);

            return RedirectToAction("Index");
        }

    }
}
