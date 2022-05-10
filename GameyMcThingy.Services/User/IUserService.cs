using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GameyMcThingy.Models.User;

namespace GameyMcThingy.Services.User
{
    public interface IUserService
    {
        Task<bool> RegisterUserAsync(UserRegister model);
    }
}