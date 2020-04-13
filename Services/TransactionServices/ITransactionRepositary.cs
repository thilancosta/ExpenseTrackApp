using ExpenseTrackApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Services.TransactionServices
{
    public interface ITransactionRepositary

    {
        int Add(ITransaction transaction);
        int Update(ITransaction transaction);
        int Delete(string id);

        IEnumerable<Object> GetAllById(string user_id);
        MySqlDataAdapter GetAllByMonth(string user_id, string month);

        Transaction GetById(string id);

    }
}
