using ExpenseTrackApp.CommonServices;
using ExpenseTrackApp.Dto;
using ExpenseTrackApp.Models;
using ExpenseTrackApp.Repos.CategoryRepo;
using ExpenseTrackApp.Services.CategoryServices;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExpenseTrackApp.Controllers
{
    class CategoryController
    {
        ICategoryRepositary _categoryRepositary = new CategoryRepo();
        IModelDataAnnotationCheck _modelDataAnnotationCheck = new ModelDataAnnotationCheck();

        public MySqlDataAdapter get_categories_by_userid(string user_id)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);

            return _categoryService.GetAllByUserId(user_id);
        }

        public int save_category(ICategory category)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.Add(category);
        }

        public int delete_cat(string id)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.Delete(id);
        }

        public List<CategoryDto> get_cats_by_userid(string id)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.GetAllById(id);
        }

        public ICategory get_category_by_id(string id)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.GetById(id);
        }

        public int update_cat(ICategory category)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.Update(category);
        }

        public CategorySummaryDto get_category_expense_summary(string user_id,string date)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.getExpensesSummary(user_id,date);
        }

        public CategorySummaryDto get_category_income_summary(string user_id, string date)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.getIncomeSummary(user_id, date);
        }

        public CategorySummaryDto get_category_expense_summary_for_year(string user_id, int date)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.getExpensesSummaryForYear(user_id, date);
        }
    }
}
