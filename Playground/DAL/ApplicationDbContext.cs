using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Playground.DAL
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        //public DbSet<TasksModel> Tasks { get; set; }
        //public DbSet<TimelogModel> Timelog { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
    }
}
