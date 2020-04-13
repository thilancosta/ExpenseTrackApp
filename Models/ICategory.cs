using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Models
{
    public interface ICategory
    {
         string categoryId { get; set; }
         string userId { get; set; }
         string category { get; set; }
         double exp_limit { get; set; }
         string type { get; set; }
    }
}
