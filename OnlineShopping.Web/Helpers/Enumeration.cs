using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Web.Helpers
{
    public static class Enumeration<T> where T:BaseModel
    {
        public static void Enumerate(List<T> models, int startIndex = 0)
        {
            for (int i = startIndex; i < models.Count; i++)
            {
                var model = models[i];
                model.No = i + 1;
            }
        }
    }
}
