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
    public class SqlEmployeeRepository : SqlBaseRepository, IEmployeeRepository
    {
        public SqlEmployeeRepository(SqlContext context) : base(context) { }
        public int Add(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Insert into Employees output inserted.id values(@Name,@Surname,
                                 @Pin,@Salary,@PhoneNumber,@IsCourier,@CreatorId,@LastModified,@IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, employee);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public List<Employee> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdTxt = "Select*from Employees where isDeleted=0";

                using (SqlCommand command = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<Employee> employees = new List<Employee>();

                    while (reader.Read())
                    {
                        Employee employee = new Employee();

                        employee.Id = Convert.ToInt32(reader["id"]);
                        employee.Name = Convert.ToString(reader["name"]);
                        employee.Surname = Convert.ToString(reader["surname"]);
                        employee.Pin = Convert.ToString(reader["pin"]);
                        employee.Salary = Convert.ToDouble(reader["salary"]);
                        employee.PhoneNumber = Convert.ToString(reader["phoneNumber"]);
                        employee.IsCourier = Convert.ToBoolean(reader["isCourier"]);

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            employee.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }
                        employee.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        employee.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                        employees.Add(employee);
                    }
                    return employees;
                }
            }
        }

        public Employee Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select * from Employees where IsDeleted = 0 and Id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Employee employee = new Employee()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Surname = Convert.ToString(reader["surname"]),
                            Pin = Convert.ToString(reader["pin"]),
                            Salary = Convert.ToDouble(reader["salary"]),
                            PhoneNumber=Convert.ToString(reader["phoneNumber"]),
                            IsCourier= Convert.ToBoolean(reader["isCourier"])
                    };

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            employee.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }
                        employee.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        employee.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                        return employee;
                    }
                    return null;
                }
            }

        }

        public bool Update(Employee employee)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Update Employees set name = @Name, surname = @Surname,
                                 pin = @Pin, salary = @Salary, phoneNumber=@PhoneNumber, isCourier=@Iscourier, 
                                 creatorId = @CreatorId, lastModified = @LastModified, isDeleted = @IsDeleted
                                 where id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, employee);
                    cmd.Parameters.AddWithValue("@Id", employee.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }

        private void AddParameters(SqlCommand cmd, Employee employee)
        {
            cmd.Parameters.AddWithValue("@Name", employee.Name);
            cmd.Parameters.AddWithValue("@Surname", employee.Surname);
            cmd.Parameters.AddWithValue("@Pin", employee.Pin);
            cmd.Parameters.AddWithValue("@Salary", employee.Salary);
            cmd.Parameters.AddWithValue("@PhoneNumber", employee.PhoneNumber);
            cmd.Parameters.AddWithValue("@IsCourier", employee.IsCourier);
            cmd.Parameters.AddWithValue("@LastModified", employee.LastModified);
            cmd.Parameters.AddWithValue("@CreatorId", employee.Creator.Id);
            cmd.Parameters.AddWithValue("@IsDeleted", employee.IsDeleted);
        }
    }
}
