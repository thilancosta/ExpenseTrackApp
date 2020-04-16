using System;

namespace ExpenseTrackApp.Models
{
    public interface ITransaction
    {
        double amount { get; set; }
        string category_id { get; set; }
        string transactionId { get; set; }
        string remarks { get; set; }
        string user_id { get; set; }
        string payer_payee { get; set; }
        DateTime timestamp { get; set; }
    }
}