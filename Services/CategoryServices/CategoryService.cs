using ExpenseTrackApp.CommonServices;
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
    class CategoryService : ICategoryService
    {
        private ICategoryRepositary _categoryRepositary;
        private IModelDataAnnotationCheck _modelDataAnnotationCheck;

        public CategoryService(ICategoryRepositary categoryRepositary, IModelDataAnnotationCheck modelDataAnnotationCheck)
        {
            _categoryRepositary = categoryRepositary;
            _modelDataAnnotationCheck = modelDataAnnotationCheck;
        }
        public int Add(ICategory category)
        {
            return _categoryRepositary.Add(category);
        }

        public int Delete(string id)
        {
            return _categoryRepositary.Delete(id);
        }

        public List<CategoryDto> GetAllById(string user_id)
        {
            return _categoryRepositary.GetAllById(user_id);
        }

        public MySqlDataAdapter GetAllByUserId(string user_id)
        {
            return _categoryRepositary.GetAllByUserId(user_id);
        }

        public Category GetById(string id)
        {
            return _categoryRepositary.GetById(id);
        }

        public CategorySummaryDto getExpensesSummary(string user_id, string date)
        {
            return _categoryRepositary.getExpensesSummary(user_id,date);
        }

        public CategorySummaryDto getExpensesSummaryForYear(string user_id, int date)
        {
            return _categoryRepositary.getExpensesSummaryForYear(user_id, date);
        }

        public CategorySummaryDto getIncomeSummary(string user_id, string date)
        {
            return _categoryRepositary.getIncomeSummary(user_id, date);
        }

        public int Update(ICategory category)
        {
            return _categoryRepositary.Update(category);
        }

        public void ValidateModel(ICategory category)
        {
             _modelDataAnnotationCheck.ValidateModel(category);
        }
    }
}
