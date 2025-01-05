using Tasks.Backend.DTOs;

namespace Tasks.Backend.DTOs
{
    public class CreateUserDTO
    {
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}

