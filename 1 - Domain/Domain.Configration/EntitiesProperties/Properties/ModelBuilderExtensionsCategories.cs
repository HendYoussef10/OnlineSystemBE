using Domain.Entities.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Configration.EntitiesProperties.Properties
{
    public static class ModelBuilderExtensionsCategories
    {
        public static ModelBuilder SeedCategories(this ModelBuilder builder)
        {
            //Seeding Category
            builder.Entity<Category>().HasData(
                new Category
                {
                    Id = new Guid("EC69C12D-B91F-4400-86F5-0D9480C520E7"),
                    Name = "Electronics",
                    IsDeleted = false,
                },
                new Category
                {
                    Id = new Guid("89a70f10-da37-483d-9829-a17ebe12dc78"),
                    Name = "Fashion",
                    IsDeleted = false,
                },
                new Category
                {
                    Id = new Guid("223634FD-7417-4B22-9E04-4BAFFBEBB8C8"),
                    Name = "Games",
                    IsDeleted = false,
                },
                new Category
                {
                    Id = new Guid("3FA85F64-5717-4562-B3FC-2C963F66AFA6"),
                    Name = "Foods",
                    IsDeleted = false,
                }
            );

   

            return builder;
        }
    }
}
