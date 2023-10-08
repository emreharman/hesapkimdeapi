using hesapkimdeapi.Models;
using Microsoft.EntityFrameworkCore;

namespace hesapkimdeapi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options):base(options){}
        public DbSet<Ad> Ads { get; set; }
        public DbSet<AdType> AdTypes { get; set; }
        public DbSet<Screen> Screens { get; set; }
    }
}