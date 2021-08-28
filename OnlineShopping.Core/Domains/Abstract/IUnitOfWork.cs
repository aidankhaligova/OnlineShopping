using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Abstract
{
    public interface IUnitOfWork
    {
        bool CheckServer();
        IUserRepository UserRepository { get; }
        IProductRepository ProductRepository { get; }
        ICustomerRepository CustomerRepository { get; }
        ICategoryRepository CategoryRepository { get; }
        IOrderRepository OrderRepository { get; }
        IEmployeeRepository EmployeeRepository { get; }
        IOrderDetailRepository OrderDetailRepository { get; }
    }
}
