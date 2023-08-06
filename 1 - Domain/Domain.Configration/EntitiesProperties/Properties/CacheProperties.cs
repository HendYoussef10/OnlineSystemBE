using Domain.Configration.EntitiesProperties.Properties.Base;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.Configration.EntitiesProperties.Properties.AccountProperties
{
    public class CacheProperties : PropertiesBase<Cache>
    {
        public override void Configure(EntityTypeBuilder<Cache> builder)
        {
            base.Configure(builder);
        }
    }
}
