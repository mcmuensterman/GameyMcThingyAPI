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
    public interface IReviewService
    {
        public Task<bool> AddReviewToGame(ReviewModel model);
        public Task<bool> DeleteReview (int reviewId);
        public Task<ReviewModel> GetReviewByGame (int gameId);
    }
}