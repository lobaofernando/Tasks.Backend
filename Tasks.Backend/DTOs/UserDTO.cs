using Tasks.Backend.Models;

namespace Tasks.Backend.DTOs
{
    public class UserDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public List<TaskItemDTO> Tasks { get; set; }
        
        // não enviar senha no DTO por ser informação sensível
        // public string Password { get; set; } // Hash em produção
    }
}
