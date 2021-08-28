using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Abstract
{
    public interface IProductRepository
    {
        int Add(Product product);
        bool Update(Product product);
        List<Product> Get();
        Product Get(int id);
    }
}
