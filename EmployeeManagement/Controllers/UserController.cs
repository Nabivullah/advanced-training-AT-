using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagement.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class UserController : ControllerBase
    {
        public readonly Repository.IUserRepository _userRepository;
        public UserController(Repository.IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [HttpGet("GetAllUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userRepository.GetAllAsync();
            return Ok(users);
        }
        [HttpGet("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userRepository.GetByIdAsync(id);
            if (user == null)
            {
                return NotFound();
            }
            return Ok(user);
        }
        [HttpPost("AddUser")]
        public async Task<IActionResult> AddUser(Models.User user)
        {
            await _userRepository.AddAsync(user);
            return CreatedAtAction(nameof(GetUserById), new { id = user.UserId }, user);
        }       
        [HttpPut("UpdateUser/{id}")]
        public async Task<IActionResult> UpdateUser(int id, Models.User user)
        {
            if (id != user.UserId)
            {
                return BadRequest();
            }
            await _userRepository.UpdateAsync(user);
            return NoContent();
        }   
        [HttpDelete("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _userRepository.DeleteAsync(id);
            return NoContent();
        }
    }
}
