using Microsoft.EntityFrameworkCore;

namespace Btec_Website
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // DbSet properties go here
    }
}
