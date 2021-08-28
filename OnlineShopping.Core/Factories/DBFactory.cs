using OnlineShopping.Core.DataAccess.SqlServer;
using OnlineShopping.Core.Domains.Abstract;
using OnlineShopping.Core.Enums;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.Factories
{
    public static class DBFactory
    {
        public static IUnitOfWork Create(ServerType serverType,string connectionString)
        {
            switch (serverType)
            {
                case ServerType.SqlServer:
                    {
                        return new SqlUnitOfWork(connectionString);
                    }
                default:
                    {
                        throw new NotSupportedException($"{serverType} not supported");
                    }
            }
        }
    }
}
