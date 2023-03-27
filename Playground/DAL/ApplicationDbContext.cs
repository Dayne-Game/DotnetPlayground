using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Playground.DAL.Models;

namespace Playground.DAL
{
    public class ApplicationDbContext : IdentityDbContext
    {
        //public DbSet<TasksModel> Tasks { get; set; }
        //public DbSet<TimelogModel> Timelog { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
    }
}
