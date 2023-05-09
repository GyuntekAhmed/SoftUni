namespace Andreys.Data
{
    using Microsoft.EntityFrameworkCore;

    using Models;

    public class AndreysDbContext : DbContext
    {
        public AndreysDbContext()
        {

        }

        public DbSet<User> Users { get; set; } = null!;

        public DbSet<Product> Products { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.
                UseSqlServer("Server=.;Database=Andreys;Integrated Security=True;");
        }
    }
}
