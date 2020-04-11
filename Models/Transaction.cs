using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Models
{
    public class Transaction : ITransaction
    {

        public string transactionId { get; set; }

        public string category_id { get; set; }

        public double amount { get; set; }
        [Required(AllowEmptyStrings = false, ErrorMessage = "Remarks are required")]
        public string remarks { get; set; }

        public string user_id { get; set; }
        public DateTime timestamp { get; set; }


    }
}
