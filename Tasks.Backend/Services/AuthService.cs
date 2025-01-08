using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Tasks.Backend.Data;
using Tasks.Backend.DTOs;
using Tasks.Backend.Models;

namespace Tasks.Backend.Services
{
    public class AuthService
    {
        private readonly IMapper _mapper;
        private readonly ApplicationDbContext _context;
        private readonly IConfiguration _configuration;

        public AuthService(IMapper mapper, ApplicationDbContext context, IConfiguration configuration)
        {
            _mapper = mapper;
            _context = context;
            _configuration = configuration;
        }

        public async Task<LoginResponseDTO?> Login(LoginDTO loginDTO) 
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == loginDTO.Email);
            if (user == null || user.Password != loginDTO.Password)
            {
                return null;
            }

            var token = GenerateJwtToken(loginDTO.Email);

            var response = new LoginResponseDTO 
                {
                    Email = loginDTO.Email,
                    Token = token
                };

            return response;
        }

        // Função para gerar o token JWT
        private string GenerateJwtToken(string email)
        {
            var key = Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]);
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Sub, email),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(ClaimTypes.Role, "User") // Exemplo: Adicionando role ao token
            };

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(1), // Tempo de validade do token
                Issuer = _configuration["Jwt:Issuer"],
                Audience = _configuration["Jwt:Audience"],
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(key),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);

            return tokenHandler.WriteToken(token);
        }
    }
}
