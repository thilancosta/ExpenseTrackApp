using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Models
{
    class Category : ICategory
    {
        public string categoryId { get; set; }
        public string userId { get; set; }
        public string category { get; set; }
        public double exp_limit { get; set; }
        public string type { get; set; }
    }
}
