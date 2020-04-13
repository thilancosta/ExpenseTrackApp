using ExpenseTrackApp.CommonServices;
using ExpenseTrackApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Services.TransactionServices
{
    public class TransactionServices : ITransactionService
    {
        private ITransactionRepositary _transactionRepositary;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TransactionServices(ITransactionRepositary transactionRepositary, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _transactionRepositary = transactionRepositary;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public int Add(ITransaction transaction)
        {
            return _transactionRepositary.Add(transaction);
        }

        public int Delete(string id)
        {
            return _transactionRepositary.Delete(id);
        }

        public IEnumerable<Object> GetAllById(string user_id)
        {
            return _transactionRepositary.GetAllById(user_id);
        }

        public MySqlDataAdapter GetAllByMonth(string user_id, string month)
        {
            return _transactionRepositary.GetAllByMonth(user_id, month);
        }

        public Transaction GetById(string id)
        {
            return _transactionRepositary.GetById(id);
        }

        public int Update(ITransaction transaction)
        {
            return _transactionRepositary.Update(transaction);
        }

        public void ValidateModel(ITransaction transaction)
        {
            _modelDataAnnotationCheck.ValidateModel(transaction);
        }
    }
}
