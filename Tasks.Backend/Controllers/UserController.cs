using Microsoft.AspNetCore.Mvc;
using Tasks.Backend.DTOs;
using Tasks.Backend.Services;

namespace Tasks.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        // GET: api/User
        [HttpGet]
        public async Task<IActionResult> GetAllUsers()
        {
            var users = await _userService.GetAllUsersAsync();

            return Ok(users);
        }

        // GET: api/User/{id}
        [HttpGet("{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);
            if (user == null) return NotFound(new { message = "Usuário não encontrado." });

            return Ok(user);
        }

        // POST: api/User
        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserDTO user)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingUser = await _userService.ExistingUser(user.Email);
            if (existingUser)
            {
                return Conflict(new { message = "O e-mail já está em uso." });
            }

            if (_userService.CreateUser(user) == null)
            {
                return StatusCode(500, new {message = "Erro na criação do usuário" });
            }

            return CreatedAtAction(nameof(GetUserById), user);
        }

        // PUT: api/User/{id}
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UserDTO updatedUser)
        {
            if (id != updatedUser.Id)
            {
                return BadRequest(new { message = "O ID do usuário não corresponde." });
            }

            if (await _userService.ExistingUser(updatedUser.Email))
            {
                return Conflict("E-mail já cadastrado");
            }

            var user = _userService.UpdateUser(id, updatedUser);

            if (user == null)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            return Ok();
        }

        // DELETE: api/User/{id}
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var user = await _userService.DeleteUserAsync(id);
            if (user == false)
            {
                return NotFound(new { message = "Usuário não encontrado." });
            }

            return Ok();
        }
    }
}

