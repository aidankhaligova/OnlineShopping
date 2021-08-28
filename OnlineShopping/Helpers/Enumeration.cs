using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Helpers
{
    public static class Enumeration
    {
        public static void Enumerate(List<CustomerModel> models, int startIndex = 0)
        {
            for (int i = startIndex; i < models.Count; i++)
            {
                var model = models[i];
                model.No = i + 1;
            }
        }

        public static void Enumerate(List<ProductModel> models, int startIndex = 0)
        {
            for (int i = startIndex; i < models.Count; i++)
            {
                var model = models[i];
                model.No = i + 1;
            }
        }

        public static void Enumerate(List<CategoryModel> models, int startIndex = 0)
        {
            for (int i = startIndex; i < models.Count; i++)
            {
                var model = models[i];
                model.No = i + 1;
            }
        }

        public static void Enumerate(List<EmployeeModel> models, int startIndex = 0)
        {
            for (int i = startIndex; i < models.Count; i++)
            {
                var model = models[i];
                model.No = i + 1;
            }
        }

        public static void Enumerate(List<OrderModel> models, int startIndex = 0)
        {
            for (int i = startIndex; i < models.Count; i++)
            {
                var model = models[i];
                model.No = i + 1;
            }
        }
    }
}
