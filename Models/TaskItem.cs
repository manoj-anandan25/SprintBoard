using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Models
{
    public class TaskItem
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; } = "";

        public string Description { get; set; } = "";

        [Required]
        public string Status { get; set; } = "ToDo"; // ToDo, InProgress, Done

        [Required]
        public string Priority { get; set; } = "Medium"; // Low, Medium, High

        public DateTime CreatedAt { get; set; } = DateTime.Now;

        // Link to Sprint
        public int? SprintId { get; set; }
        public Sprint? Sprint { get; set; }

        // Who it's assigned to
        public string? AssignedTo { get; set; }
    }
}