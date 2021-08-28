using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Mapper
{
    public class ProductMapper : BaseMapper<Product, ProductModel>
    {
        public override Product Map(ProductModel productModel)
        {
            Product product = new Product();

            product.Id = productModel.Id;
            product.Name = productModel.Name;
            product.Price = productModel.Price;
            product.Quantity = productModel.Quantity;

            CategoryMapper categoryMapper = new CategoryMapper();
            product.Category = categoryMapper.Map(productModel.Category);

            return product;
        }

        public override ProductModel Map(Product product)
        {
            ProductModel productModel = new ProductModel();

            productModel.Id = product.Id;
            productModel.Name = product.Name;
            productModel.Price = product.Price;
            productModel.Quantity = product.Quantity;

            CategoryMapper categoryMapper = new CategoryMapper();
            productModel.Category = categoryMapper.Map(product.Category);

            return productModel;
        }
    }
}
