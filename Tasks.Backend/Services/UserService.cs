using Tasks.Backend.Data;
using Tasks.Backend.Models;
using Tasks.Backend.DTOs;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserDTO> GetUserByIdAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null) return null;

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> IsEmailInUse(string email)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Email == email);

            if (user == null) return false;

            return true;
        }

        public async Task<UserDTO> CreateUserAsync(CreateUserDTO user)
        {
            _context.Users.Add(_mapper.Map<User>(user));
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO?> UpdateUserAsync(int id, UserDTO updateUser)
        {
            var user = await _context.Users.FindAsync(id);
            if (user == null)
            {
                return null;
            }

            user.Name = updateUser.Name;
            user.Email = updateUser.Email;

            _context.Entry(user).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if(user == null) return false;

            try
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateException ex)
            {
                throw new InvalidOperationException("Erro ao excluir o usuário:" + ex.Message);
            }
            catch (Exception ex)
            {
                throw new Exception("Erro inesperado");
            }
        }
    }
}
