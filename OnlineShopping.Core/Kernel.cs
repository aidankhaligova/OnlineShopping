using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Core.Domains.Abstract;

namespace OnlineShopping.Core
{
    public static class Kernel
    {
        public static User CurrentUser;
        public static IUnitOfWork DB;
    }
}
