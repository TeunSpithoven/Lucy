using LucyFrontEnd.Models;
using Microsoft.EntityFrameworkCore;
using Lucy5.Models;

namespace View.Data
{
    public class ApplicationDbContext : DbContext
    {
        // constructor voor database connectie
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        
        public DbSet<Dream> Dream { get; set; }
        public DbSet<User> User { get; set; }

    }
}
