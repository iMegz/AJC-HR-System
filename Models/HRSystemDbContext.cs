using Microsoft.EntityFrameworkCore;

namespace HR_System.Models
{
    public class HRSystemDbContext : DbContext
    {
        public HRSystemDbContext(DbContextOptions<HRSystemDbContext> options) : base(options)
        {
        }

        public DbSet<Employee> Employees { get; set; }

        public DbSet<Applicant> Applicants { get; set; }

        public DbSet<Job> Jobs { get; set; }
    }
}
