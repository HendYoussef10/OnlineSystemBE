using Domain.Configration.EntitiesProperties.Properties;
using Domain.Entities;
using Domain.Entities.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;


namespace Domain.Configration.EntitiesProperties
{
    public partial class AppDbContext : IdentityDbContext<User, Role, string, IdentityUserClaim<string>,
        UserRole, IdentityUserLogin<string>, IdentityRoleClaim<string>, IdentityUserToken<string>>
    {
        string StringConnection = "Server=localhost;Initial Catalog=OnlineShop;Integrated security=True;TrustServerCertificate=Yes;";

        public AppDbContext(DbContextOptions<AppDbContext>options) : base(options)
        {
         
        }

        public AppDbContext() : base()
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(StringConnection);

            optionsBuilder.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.AddAppDbProperties();
            builder.Seed();
            builder.SeedCategories();

        }

        public class ApplicationContextDbFactory : IDesignTimeDbContextFactory<AppDbContext>
        {
            AppDbContext IDesignTimeDbContextFactory<AppDbContext>.CreateDbContext(string[] args)
            {
                var options = new DbContextOptionsBuilder<AppDbContext>();
                return new AppDbContext(options.Options);
            }
        }
    }

}
