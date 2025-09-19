﻿namespace BackendTaskUsingGraphQL.Models
{
    public class TaskItem
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public string Status { get; set; } = "Pending"; // Pending / Completed
    }
}
