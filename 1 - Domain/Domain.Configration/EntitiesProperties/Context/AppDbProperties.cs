
using Domain.Configration.EntitiesProperties.Properties;
using Domain.Configration.EntitiesProperties.Properties.AccountProperties;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Domain.Configration.EntitiesProperties
{
    public static class AppDbProperties
    {
        public static ModelBuilder AddAppDbProperties(this ModelBuilder builder)
        {
            builder.ApplyConfiguration(new UserPropreties());
            builder.ApplyConfiguration(new UserRoleProperties());

            return builder;
        }
    }
}
