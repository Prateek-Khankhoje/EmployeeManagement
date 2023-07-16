using Microsoft.EntityFrameworkCore;

namespace EmployeeManagement.DataAccessservice.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<EmployeeModel> Employees { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<EmployeeModel>().HasData(
                new EmployeeModel() { Id=1, FirstName="Tom", LastName="Hanks", EmailId="TomHanks@gmail.com", Age=50},
                new EmployeeModel() { Id=2, FirstName = "Matt", LastName = "Damon", EmailId = "MattDamon@gmail.com", Age = 40 },
                new EmployeeModel() { Id = 3, FirstName = "Morgan", LastName = "Freeman", EmailId = "MorganFreeman@gmail.com", Age = 70 }
                );
        }
    }
}
