using ExpenseTrackApp.Models;
using ExpenseTrackApp.Services.TransactionServices;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Data.SqlClient;

namespace ExpenseTrackApp.Repos.Transaction
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

        public int Delete(int transactionId)
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

        public IEnumerable<Object> GetAllById(int user_id)
        {
            List<Object> list = new List<Object>();
            using (IDbConnection connection = new System.Data.SqlClient.SqlConnection(Helper.CnnVal("SampleDB")))
            {
                try
                {
                    String sql = "SELECT * FROM transaction LEFT JOIN category ON transaction.categoryId = category.categoryId WHERE transaction.userId=?";
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

        public ITransaction GetById(int id)
        {
            throw new NotImplementedException();
        }

        public int Update(ITransaction transaction)
        {
            throw new NotImplementedException();
        }
    }
}
