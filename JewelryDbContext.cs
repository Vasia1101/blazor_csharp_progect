using Microsoft.EntityFrameworkCore;

namespace Jewelry_Blazor_App
{
    public class JewelryDbContext : DbContext
    {
        public DbSet<JewelryStore> Stores { get; set; }
        public DbSet<Jewelry> Jewelries { get; set; }

        public JewelryDbContext(DbContextOptions<JewelryDbContext> options)
            : base(options)
        {
        }
    }
}
