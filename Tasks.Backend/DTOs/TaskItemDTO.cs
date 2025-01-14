﻿using Tasks.Backend.Models;

namespace Tasks.Backend.DTOs
{
    public class TaskItemDTO
    {
        public int Id { get; set; }
        public required string Title { get; set; }
        public required string Description { get; set; }
        public DateTime DueDate { get; set; }
        public bool IsCompleted { get; set; }
        public required int UserId { get; set; }
        
        // não enviar o user no DTO por ser informação sensível
        // public User User { get; set; }
    }
}
