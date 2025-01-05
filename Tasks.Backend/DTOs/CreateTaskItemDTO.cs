namespace Tasks.Backend.DTOs
{
    public class CreateTaskItemDTO
    {
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public required int UserId { get; set; }
    }
}
