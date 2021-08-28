using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Entities
{
    public abstract class BaseEntity
    {
        public int Id { get; set; }
        public User Creator { get; set; }
        public DateTime LastModified { get; set; } = DateTime.Now;
        public bool IsDeleted { get; set; }
    }
}
