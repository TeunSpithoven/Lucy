using LogicDataConnector.Models;
using Microsoft.EntityFrameworkCore;

namespace View
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        { }

        public DbSet<DreamDataModel> Dream { get; set; }
        public DbSet<UserDataModel> Users { get; set; }
        public DbSet<CommentDataModel> Comment { get; set; }
        public DbSet<RequestDataModel> Request { get; set; }
    }
}