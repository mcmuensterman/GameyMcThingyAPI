using System;
using System.Threading.Tasks;
using GameyMcThingy.Models.User;
using GameyMcThingy.Data.Entities;
using GameyMcThingy.Data;

namespace GameyMcThingy.Services.User
{
    public class UserService : IUserService
    {
        private readonly ApplicationDbContext _context;
        public UserService(ApplicationDbContext context)
        {
            _context = context;
        }
        
        public async Task<bool> RegisterUserAsync (UserRegister model)
        {
            var entity = new UserEntity
            {
                Email = model.Email,
                Username = model.Username,
                Password = model.Password,
                DateCreated = DateTime.Now
            };

            _context.Users.Add(entity);
            var numberOfChanges = await _context.SaveChangesAsync();

            return numberOfChanges ==1;
        }
    }
}