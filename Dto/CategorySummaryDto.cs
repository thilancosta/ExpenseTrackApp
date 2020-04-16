using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Dto
{
    public class CategorySummaryDto
    {
        public string categoryId { get; set; }
        public string userId { get; set; }
        public string category { get; set; }
        public string type { get; set; }
        public string exp_limit { get; set; }
        public double totalExpenes { get; set; }
    }
}
