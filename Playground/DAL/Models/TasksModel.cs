using System.ComponentModel.DataAnnotations;

namespace Playground.DAL.Models
{
    public class TasksModel
    {
        [Key]
        public int Id { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public string TaskName { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.NotLogged;
        public string Ticket { get; set; }
        public string Note { get; set; }
        public decimal Duration { get; set; }

    }
    public enum TaskStatus
    {
        NotLogged,
        Logged,
        Internal,
        Break
    }
}
