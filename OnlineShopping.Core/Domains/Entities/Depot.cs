using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Entities
{
    public class Depot : BaseEntity
    {
        public string Name { get; set; }
        public string Address { get; set; }
    }
}
