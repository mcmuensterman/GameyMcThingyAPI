using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameyMcThingy.Models.Category;

namespace GameyMcThingy.Services.Category
{
    public interface ICategoryService
    {
        Task<bool> CreateCategoryAsync(CategoryCreate request);
        Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync();
        Task<CategoryDetail> GetCategoryByIdAsync(int CategoryId);
        Task<bool> DeleteCategoryAsync(int categoryId);
       
    }
}