using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;

namespace GameyMcThingy.Services.Category
{
    public class CategoryService : ICategoryService
    {
        private readonly int _userId;
        public CategoryService(IHttpContextAccessor httpContextAccesor)
        {
            var userClaims = httpContextAccesor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);

            if (!validId)
                throw new Exception("Attempted to build CatergoryService without User ID claim.");
        }
    }
}