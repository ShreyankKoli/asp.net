using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccessLayer.Abstract;
using UserAccessLayer.Models;

namespace UserAccessLayer.Services
{
    public class UserRepository : IUserRepository
    {
        private readonly UsersContext context;

        public UserRepository(UsersContext context)
        {
            this.context = context;
        }

        public async Task<List<UserDetail>> GetAllUsersAsync()
        {
            return await context.UserDetails.ToListAsync();
        }

        public async Task<UserDetail> AddUserAsync(UserDetail user)
        {
            context.UserDetails.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
    }
}
