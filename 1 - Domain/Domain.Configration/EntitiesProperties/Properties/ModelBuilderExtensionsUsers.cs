using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;


namespace Domain.Configration.EntitiesProperties.Properties
{
    public static class ModelBuilderExtensionsUsers
    {
        public static ModelBuilder Seed(this ModelBuilder builder)
        {
            builder.Entity<Role>().HasData(
                new Role
                {
                    Id = "3c091dab-8a0a-4ad3-bef6-7de82ce82726",
                    Name = "Admin",
                    NormalizedName = "ADMIN",
                    IsDeleted = false,
                }
            );

            var passwordHasher = new PasswordHasher<User>();
            var admin = new User
            {
                Id = "592b0be2-2b59-4c6f-839f-6cca56e25dbc", 
                Email = "admin1@admin.com",
                PasswordHash = "",
                IsDeleted = false,
            };
            admin.PasswordHash = passwordHasher.HashPassword(admin, "admin1234");
            
            builder.Entity<User>().HasData(admin);


            builder.Entity<UserRole>().HasData(
                new UserRole
                {
                    RoleId = "3c091dab-8a0a-4ad3-bef6-7de82ce82726",
                    UserId = "592b0be2-2b59-4c6f-839f-6cca56e25dbc"
                }
            );

            return builder;
        }
    }
}
