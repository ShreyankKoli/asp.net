using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccessLayer.Models;

namespace UserAccessLayer.Abstract
{
    public interface IUserRepository
    {
        Task<List<UserDetail>> GetAllUsersAsync();

        Task<UserDetail> AddUserAsync(UserDetail user);
    }
}
