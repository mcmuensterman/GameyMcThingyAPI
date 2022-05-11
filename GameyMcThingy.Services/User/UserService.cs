using System;
using System.Collections.Generic;
using System.Linq;
using GameyMcThingy.Data.Entities;
using System.Threading.Tasks;
using GameyMcThingy.Data;
using GameyMcThingy.Models.User;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace GameyMcThingy.Services.User
{
    public class UserService : IUserService
    {
            private readonly ApplicationDbContext _context;
            public UserService(ApplicationDbContext context)
            {
                _context = context;
            }
            public async Task<bool> RegisterUserAsync(UserRegister model)
            {
                var entity = new UserEntity
                {
                    Email = model.Email,
                    Username = model.Username,
                    Password = model.Password,
                    DateCreated = DateTime.Now
                };

                var passwordHasher = new PasswordHasher<UserEntity>();
                entity.Password = passwordHasher.HashPassword(entity, model.Password);
                _context.Users.Add(entity);
                var numberOfChanges = await _context.SaveChangesAsync();

                return numberOfChanges == 1;
            }

            public async Task<UserDetail> GetUserByIdAsync(int userId)
            {
                var entity = await _context.Users.FindAsync(userId);
                if (entity is null)
                    return null;

                var userDetail = new UserDetail
                {
                    Id = entity.Id,
                    Email = entity.Email,
                    Username = entity.Username,
                    DateCreated = entity.DateCreated
                };

                return userDetail;
            }
            
         
            private async Task<UserEntity> GetUserByEmailAsync(string email)
            {
                return await _context.Users.FirstOrDefaultAsync(user => user.Email.ToLower() == email.ToLower());
            }
            private async Task<UserEntity> GetUserByUsernameAsync(string username)
            {
                return await _context.Users.FirstOrDefaultAsync(user => user.Username.ToLower() == username.ToLower());
            }
            

    }
}