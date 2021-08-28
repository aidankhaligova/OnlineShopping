using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Domains.Abstract
{
    public interface IEmployeeRepository
    {
        int Add(Employee employee);
        bool Update(Employee employee);
        List<Employee> Get();
        Employee Get(int id);
    }
}
