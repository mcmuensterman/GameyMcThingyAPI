using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using GameyMcThingy.Data;
using GameyMcThingy.Data.Entities;
using GameyMcThingy.Models.Category;

namespace GameyMcThingy.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly int _userId;
        private readonly ApplicationDbContext _dbContext;
        public CategoryService(IHttpContextAccessor httpContextAccesor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccesor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);

            if (!validId)
                throw new Exception("Attempted to build CatergoryService without User ID claim.");
            
            _dbContext = dbContext;
        }

        public async Task<bool> CreateCategoryAsync(CategoryCreate request)
        {
            var entity = new CategoryEntity
            {
                GameCategory = request.GameCategory,
                CategoryDescriptor = request.CategoryDescriptor
            };

        _dbContext.Categories.Add(entity);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;

        }
        
        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                .Select(entity => new CategoryListItem
                {
                    CategoryId = entity.CategoryId,
                    GameCategory = entity.GameCategory
                })
                .ToListAsync();

                return categories;
        }

        public async Task<CategoryDetail> GetCategoryByIdAsync(int categoryId)
                {
            // Find the first category that has given ID
            var categoryEntity = await _dbContext.Categories
                .FirstOrDefaultAsync(e =>
                    e.CategoryId == categoryId
                );
            //if null then returns null, otherwise it will init and return a NoteDetail
            return categoryEntity is null ? null : new CategoryDetail
            {
                CategoryId = categoryEntity.CategoryId,
                GameCategory = categoryEntity.GameCategory,
                CategoryDescriptor = categoryEntity.CategoryDescriptor
            };
        }

        public async Task<bool> DeleteCategoryAsync(int categoryId)
        {
            var category = await _dbContext.Categories.FindAsync(categoryId);


            _dbContext.Categories.Remove(category);
            return await _dbContext.SaveChangesAsync() == 1;
        }
    }
}