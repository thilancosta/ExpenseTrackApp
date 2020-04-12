using ExpenseTrackApp.CommonServices;
using ExpenseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Services.TransactionServices
{
    public class TransactionServices : ITransactionRepositary, ITransactionService
    {
        private ITransactionRepositary _transactionRepositary;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public TransactionServices (ITransactionRepositary transactionRepositary, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _transactionRepositary = transactionRepositary;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }

        public int Add(ITransaction transaction)
        {
            throw new NotImplementedException();
        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Object> GetAllById(string user_id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAllByMonth(string user_id, string month)
        {
            throw new NotImplementedException();
        }

        public Transaction GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Update(ITransaction transaction)
        {
            throw new NotImplementedException();
        }

        public void ValidateModel(ITransaction transaction)
        {
            _modelDataAnnotationCheck.ValidateModel(transaction);
        }
    }
}
