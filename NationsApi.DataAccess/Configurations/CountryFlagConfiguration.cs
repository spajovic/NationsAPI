using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using NationsApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NationsApi.DataAccess.Configurations
{
    public class CountryFlagConfiguration : BaseEntityConfiguration<CountryFlag>
    {
        public override void Configure(EntityTypeBuilder<CountryFlag> builder)
        {
            base.Configure(builder);

            // FilePath
            builder.Property(cf => cf.FilePath).IsRequired(false);

            // Relations
            builder.HasOne(cf => cf.Country)
                .WithMany(c => c.CountryFlags)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
