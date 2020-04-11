using ExpenseTrackApp.Models;
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
        int Delete(int id);

        IEnumerable<Object> GetAllById(int user_id);

        ITransaction GetById(int id);

    }
}
