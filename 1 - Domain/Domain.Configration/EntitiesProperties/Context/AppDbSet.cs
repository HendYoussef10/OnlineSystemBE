using Domain.Entities;
using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Configration.EntitiesProperties
{
    public partial class AppDbContext
    {
        public DbSet<Cache> Caches { set; get; }
        public DbSet<Product> Products { set; get; }
        public DbSet<Category> Categories { set; get; }
    }
}
