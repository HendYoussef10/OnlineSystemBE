using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configration.EntitiesProperties.Properties.AccountProperties
{
    public class UserPropreties : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("User");
            builder.Ignore(c => c.AccessFailedCount)
                                          .Ignore(c => c.NormalizedUserName)
                                          .Ignore(c => c.EmailConfirmed)
                                          .Ignore(c => c.SecurityStamp)
                                          .Ignore(c => c.ConcurrencyStamp)
                                          .Ignore(c => c.PhoneNumberConfirmed)
                                          .Ignore(c => c.TwoFactorEnabled)
                                          .Ignore(c => c.LockoutEnd)
                                          .Ignore(c => c.LockoutEnabled)
                                          .Ignore(c => c.NormalizedEmail);

            builder.Property(e => e.Email).IsRequired().HasMaxLength(50);

            
        }
    }
}
