using Tasks.Backend.Models;

namespace Tasks.Backend.Models
{
    public class TaskItem
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public required int UserId { get; set; }
        public User User { get; set; }
    }
}
