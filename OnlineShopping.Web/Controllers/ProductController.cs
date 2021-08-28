using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
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
    public class ProductController : BaseController
    {
        public ProductController(IUnitOfWork db, UserManager<User> userManager) : base(db, userManager) { }
        public IActionResult Index()
        {
            ViewBag.Message = TempData["Message"];

            List<Product> products = DB.ProductRepository.Get();

            ViewModel<ProductModel> viewModel = new ViewModel<ProductModel>();

            ProductMapper productMapper = new ProductMapper();

            foreach (var product in products)
            {
                var productModel = productMapper.Map(product);
                viewModel.Models.Add(productModel);
            }

            Enumeration<ProductModel>.Enumerate(viewModel.Models);

            return View(viewModel);
        }

        [HttpGet]
        public IActionResult GetProduct()
        {
            return View();
        }
        [HttpGet]
        public IActionResult SaveProduct(int id)
        {
            ProductModel model = new ProductModel();
            if (id != 0)
            {
                Product product = DB.ProductRepository.Get(id);

                if (product == null)
                    return Content("Product not found");

                ProductMapper mapper = new ProductMapper();
                model = mapper.Map(product);

                
            }
            List<Category> categories = DB.CategoryRepository.Get();
            List<SelectListItem> categoryModels = new List<SelectListItem>();

            foreach (var category in categories)
            {
                
                categoryModels.Add(new SelectListItem(category.Name, category.Id.ToString()));
            }
            model.Categories = categoryModels;
            
            return View(model);
        }

        [HttpPost]
        public IActionResult SaveProduct(ProductModel productModel)
        {
            if (ModelState.IsValid == false)
            {
                return Content("Model is invalid");
            }

            ProductMapper mapper = new ProductMapper();
            Product product = mapper.Map(productModel);

            
            product.Creator = CurrentUser;
            if (product.Id != 0)
                DB.ProductRepository.Update(product);
            else
                DB.ProductRepository.Add(product);

            TempData["Message"] = "Saved successfully";

            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult Delete(ViewModel<ProductModel> viewModel)
        {
            Product product = DB.ProductRepository.Get(viewModel.DeletedId);

            if (product == null)
                return Content("Product not found");

            product.Creator = CurrentUser;
            product.IsDeleted = true;
            product.LastModified = DateTime.Now;

            DB.ProductRepository.Update(product);

            return RedirectToAction("Index");
        }
    }
}
