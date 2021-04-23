using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Lucy5.Models;
using Microsoft.EntityFrameworkCore;

namespace Lucy5.Data
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
