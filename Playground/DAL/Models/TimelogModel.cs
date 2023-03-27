using System.ComponentModel.DataAnnotations;

namespace Playground.DAL.Models
{
    public class TimelogModel
    {
        [Key]
        public int Id { get; set; }
        public DateTime Date { get; set; }

        //[ForeignKey("User")]
        //public string UserId { get; set; }
        //public virtual ApplicationUser User { get; set; }

        public decimal LoggedTotal { get; set; }
        public decimal TotalHours { get; set; }

        public virtual ICollection<Task> Tasks { get; set; }
    }
}
