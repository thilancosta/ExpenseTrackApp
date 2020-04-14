using ExpenseTrackApp.CommonServices;
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

        public IEnumerable<object> GetAllById(string user_id)
        {
            return _categoryRepositary.GetAllById(user_id);
        }

        public MySqlDataAdapter GetAllByUserId(string user_id)
        {
            return _categoryRepositary.GetAllByUserId(user_id);
        }

        public ICategory GetById(string id)
        {
            return _categoryRepositary.GetById(id);
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
