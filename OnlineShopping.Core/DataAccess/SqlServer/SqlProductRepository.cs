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
    public class SqlProductRepository : SqlBaseRepository , IProductRepository
    {
        public SqlProductRepository(SqlContext context) : base(context) { }

        public int Add(Product product)
        {
            using(SqlConnection connection=new SqlConnection(context.ConnectionString))
            {
                connection.Open();
                string cmdText = @"Insert into Products output inserted.id values(@Name,@Quantity,
                                 @Price,@CategoryId,@CreatorId,@LastModified,@IsDeleted)";
                using(SqlCommand cmd=new SqlCommand(cmdText,connection))
                {
                    AddParameters(cmd, product);
                    return (int) cmd.ExecuteScalar();
                }
                
            }
        }
        public bool Update(Product product)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"Update Products Set name = @Name, quantity = @Quantity,
                                 price = @Price, categoryId = @CategoryId, creatorId = @CreatorId, 
                                 lastModified = @LastModified,
                                 isDeleted = @IsDeleted
                                 where id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    AddParameters(cmd,product);
                    cmd.Parameters.AddWithValue("@Id", product.Id);

                    return cmd.ExecuteNonQuery() == 1;
                }
            }
        }
        public List<Product> Get()
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdTxt = "Select p.*, c.Name as CategoryName from Products as p Inner Join Categories as c ON p.CategoryId = c.Id where p.isDeleted=0";

                using (SqlCommand command = new SqlCommand(cmdTxt, connection))
                {
                    SqlDataReader reader = command.ExecuteReader();

                    List<Product> products = new List<Product>();

                    while (reader.Read())
                    {
                        Product product = new Product();

                        product.Id = Convert.ToInt32(reader["id"]);
                        product.Name = Convert.ToString(reader["name"]);
                        product.Price = Convert.ToDouble(reader["price"]);
                        product.Quantity = Convert.ToDouble(reader["quantity"]);
                        product.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        product.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);
                        product.Category = new Category()
                        {
                            Id = Convert.ToInt32(reader["categoryId"]),
                            Name = Convert.ToString(reader["CategoryName"])
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            product.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }

                        products.Add(product);
                    }
                    return products;
                }
            }
        }
        public Product Get(int id)
        {
            using (SqlConnection connection = new SqlConnection(context.ConnectionString))
            {
                connection.Open();

                string cmdText = @"select * from Products where IsDeleted = 0 and Id = @Id";

                using (SqlCommand cmd = new SqlCommand(cmdText, connection))
                {
                    cmd.Parameters.AddWithValue("@Id", id);

                    SqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        Product product=new Product()
                        {
                            Id = Convert.ToInt32(reader["id"]),
                            Name = Convert.ToString(reader["name"]),
                            Quantity= Convert.ToDouble(reader["quantity"]),
                            Price= Convert.ToDouble(reader["price"]),
                            Category=new Category()
                            {
                                Id = Convert.ToInt32(reader["categoryId"]),
                                //Name = Convert.ToString(reader["CategoryName"])
                            }
                        };

                        if (!reader.IsDBNull(reader.GetOrdinal("creatorId")))
                        {
                            product.Creator = new User()
                            {
                                Id = Convert.ToInt32(reader["creatorId"])
                            };
                        }
                        product.LastModified = Convert.ToDateTime(reader["lastModified"]);
                        product.IsDeleted = Convert.ToBoolean(reader["isDeleted"]);

                        return product;
                    }
                    return null;
                }
            }
        }

        private void AddParameters(SqlCommand cmd,Product product)
        {
            cmd.Parameters.AddWithValue("@Name", product.Name);
            cmd.Parameters.AddWithValue("@Quantity", product.Quantity);
            cmd.Parameters.AddWithValue("@Price", product.Price);
            cmd.Parameters.AddWithValue("@CategoryId", product.Category.Id);
            cmd.Parameters.AddWithValue("@LastModified", product.LastModified);
            cmd.Parameters.AddWithValue("@CreatorId", product.Creator.Id);
            cmd.Parameters.AddWithValue("@IsDeleted", product.IsDeleted);
        }
    }
}
