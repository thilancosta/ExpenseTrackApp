using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Models
{
    class Category : ICategory
    {
        private string categoryId { get; set; }
        private string userId { get; set; }
        private string category { get; set; }
        private double exp_limit { get; set; }
        private string type { get; set; }
    }
}
