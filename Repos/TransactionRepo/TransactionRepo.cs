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
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;
                try
                {
                    string sql = "INSERT INTO transaction(transactionId, userId ,categoryId, amount, remarks, timestamp,payer_payee) VALUES(@transactionId, @userId ,@categoryId, @amount, @remarks, @timestamp,@payer_payee)";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.Parameters.AddWithValue("@transactionId", transaction.transactionId);
                        command.Parameters.AddWithValue("@userId", transaction.user_id);
                        command.Parameters.AddWithValue("@categoryId", transaction.category_id);
                        command.Parameters.AddWithValue("@amount", transaction.amount);
                        command.Parameters.AddWithValue("@remarks", transaction.remarks);
                        command.Parameters.AddWithValue("@timestamp", transaction.timestamp);
                        command.Parameters.AddWithValue("@payer_payee", transaction.payer_payee);

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

        public int Delete(string transactionId)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;

                try
                {
                    string sqlStatement = "DELETE FROM transaction WHERE transactionId = @transactionId";
                    connection.Open();
                    MySqlCommand cmd = new MySqlCommand(sqlStatement, connection);
                    cmd.Parameters.AddWithValue("@transactionId", transactionId);
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

        public IEnumerable<Object> GetAllById(string user_id)
        {
            List<Object> list = new List<Object>();
            using (IDbConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    string sql = "SELECT * FROM transaction LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId=?";
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

        public MySqlDataAdapter GetAllByMonth(string user_id, string month)
        {
            //List<Object> list = new List<Object>();
            MySqlDataAdapter adapt = new MySqlDataAdapter();
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    connection.Open();
                    //var parameters = new { userId = user_id, date = month };
                    string sql = "SELECT transactionId,transaction.remarks as Remarks,transaction.amount as Amount,category.category as Category,transaction.timestamp as Time,transaction.categoryId as categoryId,category.type as type,transaction.payer_payee as Payer_or_Payee FROM transaction  LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId= @userId AND CONCAT(YEAR(transaction.timestamp),'-',MONTH(transaction.timestamp)) = @date";

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
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                bool MatchingRecordFound = false;
                try
                {
                    string sql = "SELECT transactionId, userId, categoryId, amount, remarks, timestamp,payer_payee " +
                   "FROM transaction WHERE transactionId = @transactionId";
                    //String query = "INSERT INTO dbo.SMS_PW (id,username,password,email) VALUES (@id,@username,@password, @email)";

                    using (MySqlCommand command = new MySqlCommand(sql, connection))
                    {
                        command.CommandText = sql;
                        command.Prepare();
                        command.Parameters.Add(new MySqlParameter("@transactionId", id));
                       
                        connection.Open();
                        using (MySqlDataReader reader = command.ExecuteReader())
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
                                transaction.payer_payee = reader["payer_payee"].ToString();
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
                    MessageBox.Show("Not found a transaction");
                }
                return transaction;
            }

        }

        public int Update(ITransaction transaction)
        {
            using (MySqlConnection connection = new MySqlConnection(Helper.CnnVal("SampleDB")))
            {
                int result = 0;
                try
                {
                    connection.Open();
                    string updateSql = "UPDATE transaction SET payer_payee = @payer_payee, userId = @userId, categoryId = @categoryId, amount = @amount, remarks = @remarks WHERE transactionId = @transactionId  ";

                    using (MySqlCommand command = new MySqlCommand(updateSql, connection))
                    {
                        command.CommandText = updateSql;
                        command.Prepare();
                        command.Parameters.AddWithValue("@transactionId", transaction.transactionId);
                        command.Parameters.AddWithValue("@userId", transaction.user_id);
                        command.Parameters.AddWithValue("@categoryId", transaction.category_id);
                        command.Parameters.AddWithValue("@amount", transaction.amount);
                        command.Parameters.AddWithValue("@remarks", transaction.remarks);
                        //command.Parameters.AddWithValue("@timestamp", transaction.timestamp);
                        command.Parameters.AddWithValue("@payer_payee", transaction.payer_payee);

                        
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
