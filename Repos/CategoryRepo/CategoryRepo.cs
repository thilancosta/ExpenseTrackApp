using Dapper;
using ExpenseTrackApp.Dto;
using ExpenseTrackApp.Models;
using ExpenseTrackApp.Services.CategoryServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ExpenseTrackApp.Repos.CategoryRepo
{
    class CategoryRepo : ICategoryRepositary
    {
        public int Add(ICategory category)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    String sql = "INSERT INTO category(categoryId, userId ,category, type, exp_limit) VALUES(@categoryId, @userId ,@category, @type, @exp_limit)";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@categoryId", category.categoryId);
                        command.Parameters.AddWithValue("@userId", category.userId);
                        command.Parameters.AddWithValue("@category", category.category);
                        command.Parameters.AddWithValue("@type", category.type);
                        command.Parameters.AddWithValue("@exp_limit", category.exp_limit);

                        
                        result = command.ExecuteNonQuery();


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                return result;
            }
        }

        public int Delete(string categoryId)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;

                try
                {
                    string sqlStatement = "DELETE FROM category WHERE categoryId = @categoryId";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStatement, connection);
                    cmd.Parameters.AddWithValue("@categoryId", categoryId);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public List<CategoryDto> GetAllById(string user_id)
        {
            List<CategoryDto> list = new List<CategoryDto>();
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    string sql = "SELECT * FROM category WHERE userId=?";
                    list = connection.Query<CategoryDto>(sql, new { user_id }).ToList();
                    // var output = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();

                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                return list;
            }
        }

        public MySqlDataAdapter GetAllByUserId(string user_id)
        {
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    connection.Open();
                    string sql = "SELECT categoryId,category as Category_Name,type as Type,exp_limit as Budget_Limit FROM category WHERE userId=@userId";

                    // list = connection.Query(sql, parameters).ToList();

                    adapt = new MySqlDataAdapter(sql, connection);

                    //MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);

                    adapt.SelectCommand.Parameters.Add(new MySqlParameter("@userId", user_id));
                    //adapt.SelectCommand.Parameters.Add(new MySqlParameter("@date", month));


                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                return adapt;
            }
        }

        public Category GetById(string id)
        {
            Category category = new Category();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                bool MatchingRecordFound = false;
                try
                {
                    connection.Open();
                    string sql = "SELECT categoryId, userId, category, type, exp_limit " +
                   "FROM category WHERE categoryId = @categoryId";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandText = sql;
                        command.Prepare();
                        command.Parameters.Add(new MySqlParameter("@categoryId", id));

                        
                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {

                                category.categoryId = (reader["categoryId"].ToString());
                                category.category = reader["category"].ToString();
                                category.type = reader["type"].ToString();
                                category.exp_limit = Convert.ToDouble(reader["exp_limit"]);
                                category.userId = reader["userId"].ToString();
                            }
                        }


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                if (!MatchingRecordFound)
                {
                    MessageBox.Show("Not found a category");
                }
                return category;
            }
        }

        public int Update(ICategory category)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    string updateSql ="UPDATE category SET userId = @userId, category = @category, type = @type, exp_limit = @exp_limit WHERE categoryId = @categoryId";

                    using (MySqlCommand command = new MySqlCommand(updateSql, connection))
                    {
                        command.CommandText = updateSql;
                        command.Prepare();
                        command.Parameters.AddWithValue("@categoryId", category.categoryId);
                        command.Parameters.AddWithValue("@userId", category.userId);
                        command.Parameters.AddWithValue("@category", category.category);
                        command.Parameters.AddWithValue("@type", category.type);
                        command.Parameters.AddWithValue("@exp_limit", category.exp_limit);

                        
                        result = command.ExecuteNonQuery();


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                return result;
            }
        }

        public CategorySummaryDto getExpensesSummary(string user_id,string date)
        {
            CategorySummaryDto category_sum = new CategorySummaryDto();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                bool MatchingRecordFound = false;
                try
                {
                    connection.Open();
                    string sql = "SELECT * , SUM(amount) as totalAmount FROM transaction LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId=@userId &&  CONCAT(YEAR(timestamp),'-',MONTH(timestamp)) =@date && category.type='expense'";

                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandText = sql;
                        command.Prepare();
                        command.Parameters.Add(new MySqlParameter("@userId", user_id));
                        command.Parameters.Add(new MySqlParameter("@date", date));


                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {

                                category_sum.categoryId = (reader["categoryId"].ToString());
                                category_sum.category = reader["category"].ToString();
                                category_sum.type = reader["type"].ToString();
                                category_sum.totalExpenes = (reader["totalAmount"] == DBNull.Value) ? 0.00 : Convert.ToDouble(reader["totalAmount"]);
                                category_sum.userId = reader["userId"].ToString();
                                category_sum.exp_limit = reader["exp_limit"].ToString();
                            }
                        }


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                if (!MatchingRecordFound)
                {
                    MessageBox.Show("Not found a any expenses for this month");
                }
                return category_sum;
            }
        }

        public CategorySummaryDto getIncomeSummary(string user_id, string date)
        {
            CategorySummaryDto category_sum = new CategorySummaryDto();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                bool MatchingRecordFound = false;
                try
                {
                    connection.Open();
                    string sql = "SELECT * , SUM(amount) as totalAmount FROM transaction LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId=@userId &&  CONCAT(YEAR(timestamp),'-',MONTH(timestamp)) =@date && category.type='income'";

                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandText = sql;
                        command.Prepare();
                        command.Parameters.Add(new MySqlParameter("@userId", user_id));
                        command.Parameters.Add(new MySqlParameter("@date", date));


                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            
                            while (reader.Read())
                            {

                                category_sum.categoryId = reader["categoryId"].ToString();
                                category_sum.category = reader["category"].ToString();
                                category_sum.type = reader["type"].ToString();
                                category_sum.totalExpenes = (reader["totalAmount"] == DBNull.Value) ? 0.00 : Convert.ToDouble(reader["totalAmount"]);
                                category_sum.userId = reader["userId"].ToString();
                                category_sum.exp_limit = reader["exp_limit"].ToString();

                            }
                        }


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                if (!MatchingRecordFound)
                {
                    MessageBox.Show("Not found any income for this month");
                }
                return category_sum;
            }
        }

        public CategorySummaryDto getExpensesSummaryForYear(string user_id, int date)
        {
            CategorySummaryDto category_sum = new CategorySummaryDto();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                bool MatchingRecordFound = false;
                try
                {
                    connection.Open();
                    string sql = "SELECT * , SUM(amount) as totalAmount FROM transaction LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId=@userId &&  YEAR(timestamp) =@date && category.type='expense'";

                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandText = sql;
                        command.Prepare();
                        command.Parameters.Add(new MySqlParameter("@userId", user_id));
                        command.Parameters.Add(new MySqlParameter("@date", date));


                        using (MySqlDataReader reader = command.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {

                                category_sum.categoryId = (reader["categoryId"].ToString());
                                category_sum.category = reader["category"].ToString();
                                category_sum.type = reader["type"].ToString();
                                category_sum.totalExpenes = (reader["totalAmount"] == DBNull.Value) ? 0.00 : Convert.ToDouble(reader["totalAmount"]);
                                category_sum.userId = reader["userId"].ToString();
                                category_sum.exp_limit = reader["exp_limit"].ToString();
                            }
                        }


                    }
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                if (!MatchingRecordFound)
                {
                    MessageBox.Show("Not found a any expenses for this month");
                }
                return category_sum;
            }
        }
    }
}
