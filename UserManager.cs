using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAccessLayer.Abstract;
using UserAccessLayer.Models;
using UserAccessLayer.Services;
using UserBussinessLogicLayer.DTO;

namespace UserBussinessLogicLayer.Manager
{
    public class UserManager
    {
        private readonly IUserRepository userService;

        public UserManager(IUserRepository userService)
        {
            this.userService = userService;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await userService.GetAllUsersAsync();
            return users.Select(user => new UserDTO
            {
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber
            }).ToList();
        }

        public async Task<UserDetail> CreateUserAsync(DetailAddressDTO detailAddressDTO)
        {
            var user = new UserDetail
            {
                FirstName = detailAddressDTO.FirstName,
                LastName = detailAddressDTO.LastName,
                Email = detailAddressDTO.Email,
                PhoneNumber = detailAddressDTO.PhoneNumber,
                CreatedAt = DateTime.Now,
                UserAddresses = detailAddressDTO.UserAddresses.Select(a => new UserAddress
                {
                    Street = a.Street,
                    City = a.City,
                    State = a.State,
                    PostalCode = a.PostalCode,
                    Country = a.Country
                }).ToList()
            };

            return await userService.AddUserAsync(user);
        }
    }
}
