using ExpenseTrackApp.Dto;
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

        List<CategoryDto> GetAllById(string user_id);
        MySqlDataAdapter GetAllByUserId(string user_id);
        CategorySummaryDto getIncomeSummary(string user_id, string date);
        CategorySummaryDto getExpensesSummary(string user_id, string date);
        CategorySummaryDto getExpensesSummaryForYear(string user_id, int date);

        Category GetById(string id);
    }
}
