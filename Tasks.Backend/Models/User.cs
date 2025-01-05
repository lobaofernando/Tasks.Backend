namespace Tasks.Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; } // Hash em produção
        public List<TaskItem>? Tasks { get; set; }
    }
}
