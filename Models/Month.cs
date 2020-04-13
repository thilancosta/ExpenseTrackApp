using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Models
{
    class Month
    {
        public Month(string _id, string _name)
        {
            id = _id;
            name = _name;
        }
        public string id { get; set; }
        public string name { get; set; }
    }
}
