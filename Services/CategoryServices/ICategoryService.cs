using ExpenseTrackApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Services.CategoryServices
{
    public interface ICategoryService
    {
        void ValidateModel(ICategory category);
        int Add(ICategory category);
        int Update(ICategory category);
        int Delete(string id);

        IEnumerable<Object> GetAllById(string user_id);
        MySqlDataAdapter GetAllByUserId(string user_id);

        ICategory GetById(string id);
    }
}
