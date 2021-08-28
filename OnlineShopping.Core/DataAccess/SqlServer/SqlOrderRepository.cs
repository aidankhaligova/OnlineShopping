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
    public class SqlOrderRepository : SqlBaseRepository, IOrderRepository
    {
        public SqlOrderRepository(SqlContext context) : base(context) { }
        public int Add(Order order)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Insert into Orders output inserted.id values(
                                 @customerId,@address,@note,@creatorId,@lastModified,@isDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@customerId", order.Customer.Id);
                    cmd.Parameters.AddWithValue("@address", order.Address);
                    cmd.Parameters.AddWithValue("@note", order.Note ?? (object) DBNull.Value);
                    cmd.Parameters.AddWithValue("@lastModified", order.LastModified);
                    cmd.Parameters.AddWithValue("@creatorId", order.Creator.Id);
                    cmd.Parameters.AddWithValue("@isDeleted",order.IsDeleted);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public List<Order> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                //string cmdTxt = "Select * from Orders as o InnerJoin OrderDetails as oc ON o.Id = oc.OrderId where o.isDeleted=0 and oc.isDeleted=0";
                string cmdTxt = "Select * from Orders where isDeleted=0 ";
                using (SqlCommand command = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Order> orders = new List<Order>();

                    while (reader.Read())
                    {
                        int id = Convert.ToInt32(reader["id"]);
                        Order order = orders.FirstOrDefault(x => x.Id == id);

                        if(order == null)
                        {
                            order = new Order();
                            order.Id = id;
                            order.Customer = new Customer()
                            {
                                Id = Convert.ToInt32(reader["customerId"])
                            };
                            order.Address = Convert.ToString(reader["address"]);
                            order.Note = Convert.ToString(reader["note"]);

                            if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                            {
                                order.Creator = new User()
                                {
                                    Id = Convert.ToInt32(reader["creatorId"])
                                };
                            }
                            order.LastModified = Convert.ToDateTime(reader["lastModified"]);
                            order.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                            orders.Add(order);
                        }

                        // OrderDetail detail = new OrderDetail();

                        // set detail properties from reader

                        // order.Details.Add(detail);
                    }
                    return orders;
                }
            }
        }

        public bool Update(Order order)
        {
            throw new NotImplementedException();
        }
    }
}
