using OnlineShopping.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnlineShopping.Web.ViewModels
{
    public class ViewModel<T> where T:BaseModel
    {
        public List<T> Models { get; set; } = new List<T>();
        public int DeletedId { get; set; }
    }
}
