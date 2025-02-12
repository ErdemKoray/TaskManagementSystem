using TaskManagement.Models;
using Microsoft.EntityFrameworkCore;
namespace TaskManagement.Data
{
    public class DataContext : DbContext {
            public DataContext(DbContextOptions<DataContext> options) : base(options){}

            public DbSet<Employee> employees {get; set;}
            public DbSet<Project> projects {get; set;}
            public DbSet<ProjectTask> projectTasks {get; set;}

    }
}