using ExpenseTrackApp.CommonServices;
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

        public Object save_category(Category category)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.Add(category);
        }

        public Object delete_cat(string id)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.Delete(id);
        }

        public Object get_cats_by_userid(string id)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.GetAllById(id);
        }

        public Object get_category_by_id(string id)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.GetById(id);
        }

        public Object update_cats(Category category)
        {
            ICategoryService _categoryService = new CategoryService(_categoryRepositary, _modelDataAnnotationCheck);
            return _categoryService.Update(category);
        }
    }
}
