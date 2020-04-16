using ExpenseTrackApp.CommonServices;
using ExpenseTrackApp.Models;
using ExpenseTrackApp.Repos.TransactionRepo;
using ExpenseTrackApp.Services.TransactionServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Controllers
{
    public class TransactionController
    {
         ITransactionRepositary _transactionRepositary = new TransactionRepo();
         IModelDataAnnotationCheck _modelDataAnnotationCheck = new ModelDataAnnotationCheck();

        public MySqlDataAdapter get_transactions_by_month_userid(string user_id,string month)
        {
            ITransactionService _transactionServices = new TransactionServices(_transactionRepositary, _modelDataAnnotationCheck);
            
            return _transactionServices.GetAllByMonth(user_id, month);
        }

        public int save_transaction(ITransaction transaction)
        {
            ITransactionService _transactionServices = new TransactionServices(_transactionRepositary, _modelDataAnnotationCheck);
            return _transactionServices.Add(transaction);
        }

        public int delete_transaction(string id)
        {
            ITransactionService _transactionServices = new TransactionServices(_transactionRepositary, _modelDataAnnotationCheck);
            return _transactionServices.Delete(id);
        }

        public Object get_transactions_by_userid(string id)
        {
            ITransactionService _transactionServices = new TransactionServices(_transactionRepositary, _modelDataAnnotationCheck);
            return _transactionServices.GetAllById(id);
        }

        public Transaction get_transactions_by_id(string id)
        {
            ITransactionService _transactionServices = new TransactionServices(_transactionRepositary, _modelDataAnnotationCheck);
            return _transactionServices.GetById(id);
        }

        public int update_transaction(ITransaction transaction)
        {
            ITransactionService _transactionServices = new TransactionServices(_transactionRepositary, _modelDataAnnotationCheck);
            return _transactionServices.Update(transaction);
        }
    }
}
