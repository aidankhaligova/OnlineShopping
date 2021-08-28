using OnlineShopping.Core.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.DataAccess.SqlServer
{
    public class SqlUnitOfWork : IUnitOfWork
    {
        private readonly SqlContext context;
        public SqlUnitOfWork(string connectionString)
        {
            context = new SqlContext(connectionString);
        }
        public IUserRepository UserRepository => new SqlUserRepository(context);
        public IProductRepository ProductRepository => new SqlProductRepository(context);
        public ICustomerRepository CustomerRepository => new SqlCustomerRepository(context);
        public ICategoryRepository CategoryRepository => new SqlCategoryRepository(context);
        public IOrderRepository OrderRepository =>  new SqlOrderRepository (context);
        public IEmployeeRepository EmployeeRepository => new SqlEmployeeRepository(context);
        public IOrderDetailRepository OrderDetailRepository => new SqlOrderDetailRepository(context);

        
        public bool CheckServer()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(context.ConnectionString))
                {
                    conn.Open();

                    return true;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
