using Dapper;
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
                    String sql = "INSERT INTO transaction(transactionId, userId ,categoryId, amount, remarks, timestamp) VALUES(@categoryId, @userId ,@category, @type, @exp_limit)";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@transactionId", category.categoryId);
                        command.Parameters.AddWithValue("@userId", category.userId);
                        command.Parameters.AddWithValue("@category", category.category);
                        command.Parameters.AddWithValue("@type", category.type);
                        command.Parameters.AddWithValue("@exp_limit", category.exp_limit);

                        connection.Open();
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

        public IEnumerable<object> GetAllById(string user_id)
        {
            List<Object> list = new List<Object>();
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    string sql = "SELECT * FROM category WHERE userId=?";
                    list = connection.Query(sql, new Object[] { user_id }).ToList();
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
                    string sql = "SELECT categoryId,category as Category_Name,type as Type,exp_limit as Budget_Limit FROM category WHERE userId=?";

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
                return adapt;
            }
        }

        public ICategory GetById(string id)
        {
            Category category = new Category();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                bool MatchingRecordFound = false;
                try
                {
                    string sql = "SELECT categoryId, userId, category, type, exp_limit " +
                   "FROM category WHERE categoryId = @categoryId";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandText = sql;
                        command.Prepare();
                        command.Parameters.Add(new MySqlParameter("@categoryId", id));

                        connection.Open();
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
                    string updateSql =
               "UPDATE category "
             + "SET categoryId = @categoryId, "
             + "userId = @userId, "
             + "category = @category, "
             + "type = @type, "
             + "exp_limit = @exp_limit, ";

                    using (MySqlCommand command = new MySqlCommand(updateSql, connection))
                    {
                        command.Parameters.AddWithValue("@categoryId", category.categoryId);
                        command.Parameters.AddWithValue("@userId", category.userId);
                        command.Parameters.AddWithValue("@category", category.category);
                        command.Parameters.AddWithValue("@type", category.type);
                        command.Parameters.AddWithValue("@exp_limit", category.exp_limit);

                        connection.Open();
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
    }
}
