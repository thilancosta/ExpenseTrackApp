using ExpenseTrackApp.Models;
using ExpenseTrackApp.Services.CategoryServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Repos.CategoryRepo
{
    class CategoryRepo : ICategoryRepositary
    {
        public int Add(ICategory category)
        {
            throw new NotImplementedException();
        }

        public int Delete(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<object> GetAllById(string user_id)
        {
            throw new NotImplementedException();
        }

        public MySqlDataAdapter GetAllByMonth(string user_id, string month)
        {
            throw new NotImplementedException();
        }

        public ICategory GetById(string id)
        {
            throw new NotImplementedException();
        }

        public int Update(ICategory category)
        {
            throw new NotImplementedException();
        }
    }
}
