using System;
using System.Collections.Generic;
using System.Linq;
using GameyMcThingy.Data.Entities;
using System.Threading.Tasks;
using GameyMcThingy.Data;
using GameyMcThingy.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using GameyMcThingy.Models;

namespace GameyMcThingy.Services.Review
{
    public class ReviewService
    {
        private readonly ApplicationDbContext _context;
        public ReviewService(ApplicationDbContext context)
        {
            _context = context;
        }

        // Add Review to Game
        public async Task<bool> AddReviewToGame(ReviewModel model)
        {
            // map model to review entity and save.
            var entity = new ReviewEntity
            {
                ReviewTitle = model.ReviewTitle,
                ReviewComment = model.ReviewComment,
                GameId = model.GameId
            };

            _context.Reviews.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges == 1;
        }
    }
}