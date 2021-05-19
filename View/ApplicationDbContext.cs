using Microsoft.EntityFrameworkCore;
using View.Models;

namespace View
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<DreamViewModel> Dream { get; set; }
    }
}