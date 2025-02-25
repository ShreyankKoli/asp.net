using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UserBussinessLogicLayer.DTO;
using UserBussinessLogicLayer.Manager;

namespace UserPresentationLayer.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserManager usermanager;

        public UserController(UserManager usermanager)
        {
            this.usermanager = usermanager;
        }

        [HttpGet("GetAll")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await usermanager.GetAllUsersAsync();
            if (users == null || !users.Any())
            {
                return NotFound(new { message = "No users found" });
            }
            return Ok(users);
        }

        [HttpPost("create")]
        public async Task<ActionResult> CreateUser([FromBody] DetailAddressDTO detailAddressDTO)
        {
            if (detailAddressDTO == null)
            {
                return BadRequest("Invalid input");
            }

            var createdUser = await usermanager.CreateUserAsync(detailAddressDTO);
            return Ok("Created");
        }
    }
}
