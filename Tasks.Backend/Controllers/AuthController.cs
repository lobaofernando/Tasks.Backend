using Microsoft.AspNetCore.Mvc;
using Tasks.Backend.DTOs;
using Tasks.Backend.Services;

namespace Tasks.Backend.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : Controller
    {
        private readonly AuthService _authService;

        public AuthController(AuthService authService)
        {
            _authService = authService;
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginDTO loginDTO)
        {
            var loginResponse = await _authService.Login(loginDTO);

            if (loginResponse == null) return Unauthorized("Usuário não encontrado ou senha incorreta");

            return Ok(loginResponse);
        }
    }
}
