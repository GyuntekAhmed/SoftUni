using Microsoft.EntityFrameworkCore;

namespace ASPNETCoreDatabases.Infrastructure.Model
{
    public class WebShopDbContext : DbContext
    {
        public WebShopDbContext(DbContextOptions<WebShopDbContext> options)
            : base(options)
        {

        }

        public DbSet<Product> Products { get; set; }

        public DbSet<ProductNote> ProductNotes { get; set; }
    }
}
