using Microsoft.EntityFrameworkCore;

namespace AdaApi.Models
{
    public class ApplicationDbContext: DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options) { }

        public DbSet<Productos> Productos { get; set; }
    }
}
