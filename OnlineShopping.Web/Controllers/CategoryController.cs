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
    public class CategoryController : BaseController
    {
       
        public CategoryController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager) { }

        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];

            List<Category> categories = DB.CategoryRepository.Get();

            ViewModel<CategoryModel> viewModel = new ViewModel<CategoryModel>();

            CategoryMapper categoryMapper = new CategoryMapper();

            foreach (var category in categories)
            {
                var categoryModel = categoryMapper.Map(category);
                viewModel.Models.Add(categoryModel);
            }

            Enumeration<CategoryModel>.Enumerate(viewModel.Models);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetCategory(int id)
        {
            if (id != 0)
            {
                Category category = DB.CategoryRepository.Get(id);

                if (category == null)
                    return Content("Filial tapılmadı");

                CategoryMapper mapper = new CategoryMapper();
                CategoryModel model = mapper.Map(category);

                return View(model);
            }

            return View(new CategoryModel());
        }
        [HttpGet]
        public IActionResult SaveCategory(int id)
        {
            if (id != 0)
            {
                Category category = DB.CategoryRepository.Get(id);

                if (category == null)
                    return Content("Category not found");

                CategoryMapper mapper = new CategoryMapper();
                CategoryModel model = mapper.Map(category);

                return View(model);
            }

            return View(new CategoryModel());
        }

        [HttpPost]
        public IActionResult SaveCategory(CategoryModel categoryModel)
        {
            if (ModelState.IsValid == false)
            {
                return Content("Model is invalid");
            }

            CategoryMapper mapper = new CategoryMapper();
            Category category = mapper.Map(categoryModel);

            
            category.Creator = CurrentUser;
            if (category.Id != 0)
                DB.CategoryRepository.Update(category);
            else
                DB.CategoryRepository.Add(category);

            TempData["Message"] = "Saved successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(ViewModel<CategoryModel> viewModel)
        {
            Category category = DB.CategoryRepository.Get(viewModel.DeletedId);

            if (category == null)
                return Content("Category not found");

            category.Creator = CurrentUser;
            category.IsDeleted = true;
            category.LastModified = DateTime.Now;

            DB.CategoryRepository.Update(category);

            return RedirectToAction("Index");
        }

    }
}
