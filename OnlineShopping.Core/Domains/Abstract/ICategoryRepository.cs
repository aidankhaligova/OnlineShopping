using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Abstract
{
    public interface ICategoryRepository
    {
        int Add(Category category);
        bool Update(Category category);
        List<Category> Get();
        Category Get(int id);
    }
}
