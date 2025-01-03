using Tasks.Backend.Data;
using Tasks.Backend.Models;
using Tasks.Backend.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System.Runtime.Intrinsics.Arm;

namespace Tasks.Backend.Services
{
    public class UserService
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;

        public UserService(ApplicationDbContext context, IMapper mapper) 
        {
            _mapper = mapper;
            _context = context;
        }

        public async Task<List<UserDTO>> GetAllUsersAsync()
        {
            var users = await _context.Users.ToListAsync();

            return _mapper.Map<List<UserDTO>>(users);
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> ExistingUser(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null) return false;

            return true;
        }

        public async Task<UserDTO> CreateUser(User user)
        {
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }
    }
}
