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
    public class SqlCategoryRepository : SqlBaseRepository, ICategoryRepository
    {
        public SqlCategoryRepository(SqlContext context) : base(context) { }
        public int Add(Category category)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Insert into Categories output inserted.id values(
                                 @Name,@CreatorId,@LastModified,@IsDeleted)";
                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, category);
                    return (int)cmd.ExecuteScalar();
                }
            }
        }
        public List<Category> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdTxt = "Select*from Categories where isDeleted=0";

                using (SqlCommand command = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();
                    List<Category> categories = new List<Category>();

                    while (reader.Read())
                    {
                        Category category = new Category
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"])
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            category.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }
                        category.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        category.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                        categories.Add(category);
                    }
                    return categories;
                }
            }
        }

        public Category Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select * from Categories where IsDeleted = 0 and Id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Category category = new Category
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"])
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            category.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }
                        category.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        category.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                        return category;
                    }
                    return null;
                }
            }
        }

        public bool Update(Category category)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Update Categories set name = @Name, creatorId = @CreatorId, 
                                 lastModified = @LastModified,
                                 isDeleted = @IsDeleted
                                 where id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd, category);
                    cmd.Parameters.AddWithValue("@Id", category.Id);

                    return (int)cmd.ExecuteNonQuery() == 1;
                }
                
            }
        }

        

        private void AddParameters(SqlCommand cmd, Category category)
        {
            cmd.Parameters.AddWithValue("@Name", category.Name);
            cmd.Parameters.AddWithValue("@LastModified", category.LastModified);
            cmd.Parameters.AddWithValue("@CreatorId", category.Creator.Id);
            cmd.Parameters.AddWithValue("@IsDeleted", category.IsDeleted);
        }
    }
}
