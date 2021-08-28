using System;
using System.Collections.Generic;
using System.Text;

namespace OnlineShopping.Core.Domains.Entities
{
    public class UserRole
    {
        public int Id { get; set; }
        public User User { get; set; }
        public Role Role { get; set; }
    }
}
