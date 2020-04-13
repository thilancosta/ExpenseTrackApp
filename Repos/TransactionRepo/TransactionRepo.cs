using ExpenseTrackApp.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;
using ExpenseTrackApp.Models;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace ExpenseTrackApp.Repos.TransactionRepo
{
    class TransactionRepo : ITransactionRepositary
    {
        public int Add(ITransaction transaction)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;
                try
                {
                    String sql = "INSERT INTO transaction(transactionId, userId ,categoryId, amount, remarks, timestamp) VALUES(@transactionId, @userId ,@categoryId, @amount, @remarks, @timestamp)";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@transactionId", transaction.transactionId);
                        command.Parameters.AddWithValue("@userId", transaction.user_id);
                        command.Parameters.AddWithValue("@categoryId", transaction.category_id);
                        command.Parameters.AddWithValue("@amount", transaction.amount);
                        command.Parameters.AddWithValue("@remarks", transaction.remarks);
                        command.Parameters.AddWithValue("@timestamp", transaction.timestamp);

                        connection.Open();
                        result = command.ExecuteNonQuery();

                        
                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                return result;
            }
        }

        public int Delete(string transactionId)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;

                try
                {
                    string sqlStatement = "DELETE FROM transaction WHERE transactionId = @transactionId";
                    connection.Open();
                    SqlCommand cmd = new SqlCommand(sqlStatement, connection);
                    cmd.Parameters.AddWithValue("@transactionId", transactionId);
                    cmd.CommandType = CommandType.Text;
                    result = cmd.ExecuteNonQuery();

                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                return result;
            }
        }

        public IEnumerable<Object> GetAllById(string user_id)
        {
            List<Object> list = new List<Object>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    string sql = "SELECT * FROM transaction LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId=?";
                    list = connection.Query(sql, new Object[] { user_id }).ToList();
                    // var output = connection.Query<Person>("dbo.People_GetByLastName @LastName", new { LastName = lastName }).ToList();
                    
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                return list;
            }
        }

        public MySqlDataAdapter GetAllByMonth(string user_id, string month)
        {
            List<Object> list = new List<Object>();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    connection.Open();
                    var parameters = new { userId = user_id, date = month };
                    string sql = "SELECT transaction.remarks as remarks,transaction.amount as amount,category.category as category,transaction.timestamp as date FROM transaction  LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId= @userId AND CONCAT(YEAR(transaction.timestamp),'-',MONTH(transaction.timestamp)) = @date";

                    // list = connection.Query(sql, parameters).ToList();

                    adapt = new MySqlDataAdapter(sql, connection);

                    //MySqlCommand mySqlCommand = new MySqlCommand(sql, connection);
                                       
                    adapt.SelectCommand.Parameters.Add(new MySqlParameter("@userId", user_id));
                    adapt.SelectCommand.Parameters.Add(new MySqlParameter("@date", month));

                    

                    //MySqlDataReader reader = mySqlCommand.ExecuteReader();
                    //string output = "";
                    //foreach (var s in list)
                    //{
                    //    Console.WriteLine("he");
                    //    output = output + s + "\n";
                    //}
                    //while (reader.Read())
                    //{
                    //    output = output + reader.GetValue(0) +  "\n";
                    //}
                    //MessageBox.Show(output);
                    //connection.Close();

                    //string output = "";
                    //foreach (var s in list)
                    //{
                    //    Console.WriteLine("he");
                    //    output = output + s + "\n";
                    //}
                    //MessageBox.Show(output);
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                }
                return adapt;
            }
        }

        public Transaction GetById(string id)
        {
            Transaction transaction = new Transaction();
            using (SqlConnection connection = new SqlConnection(Helper.CnnVal("SampleDB")))
            {
                bool MatchingRecordFound = false;
                try
                {
                    string sql = "SELECT transactionId, userId, categoryId, amount, remarks, timestamp " +
                   "FROM transaction WHERE transactionId = @transactionId";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        command.CommandText = sql;
                        command.Prepare();
                        command.Parameters.Add(new SqlParameter("@DepartmentId", id));
                       
                        connection.Open();
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            MatchingRecordFound = reader.HasRows;
                            while (reader.Read())
                            {

                                transaction.transactionId = (reader["transactionId"].ToString());
                                transaction.category_id = reader["categoryId"].ToString();
                                transaction.remarks = reader["remarks"].ToString();
                                transaction.amount = Convert.ToDouble(reader["amount"]);
                                transaction.timestamp = Convert.ToDateTime(reader["timestamp"]);
                                transaction.user_id = reader["userId"].ToString();
                            }
                        }


                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
                }
                finally
                {
                    connection.Close();
                }
                // Check Error
                if (!MatchingRecordFound)
                {
                    throw new Exception("Not found a transaction");
                }
                return transaction;
            }

        }

        public int Update(ITransaction transaction)
        {
            using (SqlConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;
                try
                {
                    string updateSql =
               "UPDATE transaction "
             + "SET transactionId = @transactionId, "
             + "userId = @userId, "
             + "categoryId = @categoryId, "
             + "amount = @amount, "
             + "remarks = @remarks, "
             + "timestamp = @timestamp ";

                    using (SqlCommand command = new SqlCommand(updateSql, connection))
                    {
                        command.Parameters.AddWithValue("@transactionId", transaction.transactionId);
                        command.Parameters.AddWithValue("@userId", transaction.user_id);
                        command.Parameters.AddWithValue("@categoryId", transaction.category_id);
                        command.Parameters.AddWithValue("@amount", transaction.amount);
                        command.Parameters.AddWithValue("@remarks", transaction.remarks);
                        command.Parameters.AddWithValue("@timestamp", transaction.timestamp);

                        connection.Open();
                        result = command.ExecuteNonQuery();


                    }
                }
                catch (Exception e)
                {
                    throw new Exception(e.Message);
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
