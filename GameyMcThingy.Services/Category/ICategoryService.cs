using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameyMcThingy.Models.Category;

namespace GameyMcThingy.Services.Category
{
    public interface ICategoryService
    {
       public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories
            .Select(entity => new CategoryListItem
            {
                Id = entity.Id,
                GameCategory = entity.GameCategory
            })
            .ToListAsync();

            return categories;
        }
    }
}