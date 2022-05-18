using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using GameyMcThingy.Data;

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
            var category = new Category
            {
                GameCategory = request.GameCategory,
                Description = request.Description,
            };

        _dbContext.Categories.Add(category);

        var numberOfChanges = await _dbContext.SaveChangesAsync();
        return numberOfChanges == 1;

        }

        public async Task<IEnumerable<CategoryListItem>> GetAllCategoriesAsync()
        {
            var categories = await _dbContext.Categories
                .Select(entity => new CategoryListItem
                {
                    CategoryId = entity.CategoryId,
                    CategoryName = entity.GameCategory
                })
                .ToListAsync();
        }
    }
}