using Employee_Tracker.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee_Tracker.Data
{
    public class ApplicationDbContext:DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        public DbSet<Employee> Employees { get; set; }  

        public DbSet<Department> Departments { get; set; }
    }
}
