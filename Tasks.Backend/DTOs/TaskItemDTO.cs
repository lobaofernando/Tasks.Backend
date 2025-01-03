using Tasks.Backend.Models;

namespace Tasks.Backend.DTOs
{
    public class TaskItemDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public int UserId { get; set; }
        
        // não enviar o user no DTO por ser informação sensível
        // public User User { get; set; }
    }
}
