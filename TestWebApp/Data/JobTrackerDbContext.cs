using Microsoft.EntityFrameworkCore;
using TestWebApp.Models;

namespace TestWebApp.Data
{
    public class JobTrackerDbContext: DbContext
    {
        public JobTrackerDbContext(DbContextOptions<JobTrackerDbContext> options): base(options)
        {
        }
        public DbSet<Application> Applications { get; set; }
        public DbSet<JobDesc> JobDescs { get; set; }
    }
}
