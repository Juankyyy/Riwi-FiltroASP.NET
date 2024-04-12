using Microsoft.EntityFrameworkCore;
using Empleo.Models;

namespace Empleo.Data
{
    public class EmpleoContext : DbContext
    {
        public EmpleoContext(DbContextOptions<EmpleoContext> options): base(options)
        {

        }

        public DbSet<Job> Jobs { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}