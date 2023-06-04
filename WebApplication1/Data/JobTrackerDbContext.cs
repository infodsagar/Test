using Microsoft.EntityFrameworkCore;
using TestRazorWebApp.Models;

namespace TestRazorWebApp.Data
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
