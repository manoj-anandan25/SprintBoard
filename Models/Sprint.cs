using System.ComponentModel.DataAnnotations;

namespace TaskFlow.Models
{
    public class Sprint
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = "";

        public string Goal { get; set; } = "";

        [Required]
        public DateTime StartDate { get; set; }

        [Required]
        public DateTime EndDate { get; set; }

        public bool IsActive { get; set; } = false;

        // One sprint has many tasks
        public List<TaskItem> Tasks { get; set; } = new List<TaskItem>();
    }
}