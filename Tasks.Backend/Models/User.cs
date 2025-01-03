namespace Tasks.Backend.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // Hash em produção
        public List<TaskItem> Tasks { get; set; }
    }
}
