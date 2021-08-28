using OnlineShopping.Core.Domains.Entities;
using OnlineShopping.Core.Domains.Abstract;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OnlineShopping.Core.DataAccess.SqlServer
{
    public class SqlUserRepository : SqlBaseRepository, IUserRepository
    {
        public SqlUserRepository(SqlContext context) : base(context) { }
        public User Get(string username)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"select u.*, ur.id as UserRoleId, ur.RoleId, r.Name as RoleName from Users as u Inner Join UserRoles as ur  ON u.id = ur.UserId 
                    Inner Join Roles as r ON ur.RoleId = r.id
                    where u.username = @username and u.isDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    var reader = cmd.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        ReadFromReader(reader, ref user);
                    }

                    return user;
                }
            }
        }

        public User Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"select u.*, ur.id as UserRoleId, ur.RoleId, r.Name as RoleName from Users as u Inner Join UserRoles as ur  ON u.id = ur.UserId 
                    Inner Join Roles as r ON ur.RoleId = r.id
                    where u.id = @id and u.isDeleted = 0";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@id", id);
                    var reader = cmd.ExecuteReader();
                    User user = null;

                    while (reader.Read())
                    {
                        ReadFromReader(reader, ref user);
                    }

                    return user;
                }
            }
        }

        private void ReadFromReader(SqlDataReader reader, ref User user)
        {
           if(user==null)
           {
                user = new User();

                user.Id = Convert.ToInt32(reader["id"]);
                user.Username = Convert.ToString(reader["username"]);
                user.Password = Convert.ToString(reader["password"]);
                user.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                user.LastModified = Convert.ToDateTime(reader["lastModified"]);
                if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                {
                    user.Creator = new User()
                    {
                        Id = Convert.ToInt32(reader["creatorId"])
                    };
                }
           }
            UserRole userRole = new UserRole();

            userRole.Id = Convert.ToInt32(reader["UserRoleId"]); ;
            userRole.User = user;
            userRole.Role = new Role();
            userRole.Role.Id = Convert.ToInt32(reader["RoleId"]); ;
            userRole.Role.Name = Convert.ToString(reader["RoleName"]);

            user.UserRoles.Add(userRole);
        }
    }
}
