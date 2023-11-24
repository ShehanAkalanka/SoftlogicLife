using Microsoft.EntityFrameworkCore;
using SoftlogicLife.Models;

namespace SoftlogicLife.Data
{
    public class SoftlogicLifeDbContext:DbContext
    {
        public SoftlogicLifeDbContext(DbContextOptions<SoftlogicLifeDbContext> options):base(options)
        {
            
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
