using Microsoft.AspNetCore.Mvc;
using UserManagementSharding.Models;
using UserManagementSharding.Services;

namespace UserManagementSharding.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly UserService _userService;

        public UsersController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public async Task<IActionResult> AddUser([FromBody] User user)
        {
            await _userService.AddUser(user);
            return Ok("User added successfully");
        }

        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();
            return Ok(users);
        }
        [HttpDelete("{id}")]     
public async Task<IActionResult> DeleteUser(int id)
{
    bool result = await _userService.DeleteUserById(id);
    if (!result) return NotFound();
    return Ok("User deleted successfully");
}

[HttpDelete]               
public async Task<IActionResult> DeleteAllUsers()
{
    await _userService.DeleteAllUsers();
    return Ok("All users deleted successfully");
}

    }
}
