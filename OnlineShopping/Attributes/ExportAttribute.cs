using OnlineShopping.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Attributes
{
    public class ExportAttribute : Attribute
    {
        public int ColumnNo { get; set; }
        public string Name { get; set; }
    }
}
