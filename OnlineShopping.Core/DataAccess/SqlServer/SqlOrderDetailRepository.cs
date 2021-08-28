using OnlineShopping.Core.Domains.Abstract;
using OnlineShopping.Core.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.DataAccess.SqlServer
{
    public class SqlOrderDetailRepository : SqlBaseRepository, IOrderDetailRepository
    {
        public SqlOrderDetailRepository(SqlContext context) : base(context)
        {

        }
        public int Add(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> Get()
        {
            throw new NotImplementedException();
        }

        public List<OrderDetail> GetOrderDetails(int orderId)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                
                string cmdTxt = "Select * from OrderDetails where isDeleted=0 and orderId=@orderId";

                using (SqlCommand command = new SqlCommand(cmdTxt, connection))
                {
                    command.Parameters.AddWithValue("@orderId",orderId);
                    SqlDataReader reader = command.ExecuteReader();

                    List<OrderDetail> orderDetails = new List<OrderDetail>();

                    while (reader.Read())
                    {
                        OrderDetail orderDetail = new OrderDetail();

                        orderDetail.Id = Convert.ToInt32(reader["id"]);
                        orderDetail.Product = new Product
                        {
                            Id = Convert.ToInt32(reader["productId"])
                        };
                        orderDetail.OrderCount = Convert.ToDouble(reader["orderCount"]);
                        orderDetail.Order = new Order
                        {
                            Id = Convert.ToInt32(reader["orderId"])
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            orderDetail.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }
                        orderDetail.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        orderDetail.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                        orderDetails.Add(orderDetail);
                    }
                    return orderDetails;
                }
            }
        }

        public bool Update(OrderDetail orderDetail)
        {
            throw new NotImplementedException();
        }
    }
}
