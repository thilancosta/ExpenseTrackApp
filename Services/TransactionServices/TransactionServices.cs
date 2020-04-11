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

        public int Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Object> GetAllById(int user_id)
        {
            throw new NotImplementedException();
        }

        public ITransaction GetById(int id)
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
