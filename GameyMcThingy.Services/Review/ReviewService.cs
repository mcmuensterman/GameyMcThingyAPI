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
using Microsoft.AspNetCore.Http;
using System.Security.Claims;

namespace GameyMcThingy.Services.Review
{
    public class ReviewService : IReviewService
    {
        private readonly ApplicationDbContext _context;
        private readonly int _userId;
        public ReviewService(IHttpContextAccessor httpContextAccesor, ApplicationDbContext dbContext)
        {
            var userClaims = httpContextAccesor.HttpContext.User.Identity as ClaimsIdentity;
            var value = userClaims.FindFirst("Id")?.Value;
            var validId = int.TryParse(value, out _userId);

            if (!validId)
                throw new Exception("Attempted to build CatergoryService without User ID claim.");
            
            _context = dbContext;
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

        //Delete Review
        public async Task<bool> DeleteReview (int reviewId)
        {
            var entity = await _context.Reviews.FindAsync(reviewId);
                if (entity is null)
                    return false;

            _context.Reviews.Remove(entity);

            var numberOfChanges = await _context.SaveChangesAsync();
            return numberOfChanges == 1;
        }

        //Get Reviews by GameId
        public async Task<ReviewModel> GetReviewByGame (int gameId)
        {
            var entity = await _context.Reviews.FindAsync(gameId);
                if (entity is null)
                    return null;

                var reviewModel = new ReviewModel
                {
                    ReviewId = entity.ReviewId,
                    ReviewTitle = entity.ReviewTitle,
                    ReviewComment = entity.ReviewComment
                };

                return reviewModel;
        }

        //Update a Review
        public async Task<ReviewModel> UpdateReview (ReviewModel model)
        {
            var entity = _context.Reviews.Find(model.ReviewId);

            if(entity is null)
            return null;

            entity.ReviewTitle = model.ReviewTitle;
            entity.ReviewComment = model.ReviewComment;

            await _context.SaveChangesAsync();

            return model;
        }

    }
}