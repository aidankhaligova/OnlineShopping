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
    public class SqlCustomerRepository : SqlBaseRepository, ICustomerRepository
    {
        public SqlCustomerRepository(SqlContext context) : base(context) { }
        public int Add(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Insert into Customers output inserted.id values(@name,@surname,
                                 @address,@phoneNumber,@creatorId,@lastModified,@isDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@name", customer.Name);
                    cmd.Parameters.AddWithValue("@surname", customer.Surname);
                    cmd.Parameters.AddWithValue("@address", customer.Address);
                    cmd.Parameters.AddWithValue("@phoneNumber", customer.PhoneNumber);
                    cmd.Parameters.AddWithValue("@creatorId", customer.Creator.Id);
                    cmd.Parameters.AddWithValue("@lastModified", customer.LastModified);
                    cmd.Parameters.AddWithValue("@isDeleted", customer.IsDeleted);
                    return (int)cmd.ExecuteScalar();
                }

            }
        }
        public List<Customer> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdTxt = "Select * from Customers where isDeleted=0";

                using (SqlCommand command = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<Customer> customers = new List<Customer>();

                    while (reader.Read())
                    {
                        Customer customer = new Customer();

                        customer.Id = Convert.ToInt32(reader["id"]);
                        customer.Name = Convert.ToString(reader["name"]);
                        customer.Surname = Convert.ToString(reader["surname"]);
                        customer.Address= Convert.ToString(reader["address"]);
                        customer.PhoneNumber= Convert.ToString(reader["phoneNumber"]);

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            customer.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }
                        customer.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        customer.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                        customers.Add(customer);
                    }
                    return customers;
                }
            }
        }

        public Customer Get(int id)
        {
            using (SqlConnection conn = new SqlConnection(context.ConnectionString))
            {
                conn.Open();

                string cmdText = @"select * from Customers where IsDeleted = 0 and Id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, conn))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Customer customer = GetFromReader(reader);

                        return customer;
                    }

                    return null;
                }
            }
        }

        public bool Update(Customer customer)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Update Customers Set name = @Name, surname=@Surname,
                                 address=@Address,phoneNumber=@PhoneNumber,creatorId = @CreatorId, 
                                 lastModified = @LastModified,
                                 isDeleted = @IsDeleted
                                 where id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, customer);
                    cmd.Parameters.AddWithValue("@Id", customer.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
        private Customer GetFromReader(SqlDataReader reader)
        {
            Customer customer = new Customer();

            customer.Id = Convert.ToInt32(reader["id"]);
            customer.Name = Convert.ToString(reader["name"]);
            customer.Surname = Convert.ToString(reader["surname"]);
            customer.Address = Convert.ToString(reader["address"]);
            customer.PhoneNumber = Convert.ToString(reader["phoneNumber"]);

            if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
            {
                customer.Creator = new User()
                {
                    Id = Convert.ToInt32(reader["creatorId"])
                };
            }
            customer.LastModified = Convert.ToDateTime(reader["lastModified"]);
            customer.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
            return customer;
        }
        private void AddParameters(SqlCommand cmd, Customer customer)
        {
            cmd.Parameters.AddWithValue("@Name", customer.Name);
            cmd.Parameters.AddWithValue("@Surname", customer.Surname);
            cmd.Parameters.AddWithValue("@PhoneNumber", customer.PhoneNumber);
            cmd.Parameters.AddWithValue("@Address", customer.Address);
            cmd.Parameters.AddWithValue("@LastModified", customer.LastModified);
            cmd.Parameters.AddWithValue("@CreatorId", customer.Creator.Id);
            cmd.Parameters.AddWithValue("@IsDeleted", customer.IsDeleted);
        }

    }
}
