using ExpenseTrackApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Services.TransactionServices
{
    interface ITransactionService
    {
        void ValidateModel(ITransaction transaction);
    }
}
