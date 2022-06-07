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
    public class RegionConfiguration : BaseEntityConfiguration<Region>
    {
        public override void Configure(EntityTypeBuilder<Region> builder)
        {
            base.Configure(builder);

            // Name
            builder.Property(r => r.Name)
                .HasMaxLength(100)
                .IsRequired(true);

            builder.HasIndex(r => r.Name).IsUnique();

            // Relations
            builder.HasOne(r => r.Continent)
                .WithMany(c => c.Regions)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Countries)
                .WithOne(c => c.Region)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
