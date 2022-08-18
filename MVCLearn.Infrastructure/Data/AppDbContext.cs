using Microsoft.EntityFrameworkCore;
using MVCLearn.Domain;

namespace MVCLearn.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext() { }
        public AppDbContext(DbContextOptions<AppDbContext> dbContextOptions) : base(dbContextOptions) { }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Publication> Publications { get; set; }

    }
}
