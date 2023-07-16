using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccessservice.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeeModel> Employees { get; set; }
    }
}
