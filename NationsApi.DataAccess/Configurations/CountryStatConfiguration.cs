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
    public class CountryStatConfiguration : IEntityTypeConfiguration<CountryStat>
    {
        public void Configure(EntityTypeBuilder<CountryStat> builder)
        {
            // Year
            builder.Property(cs => cs.Year).IsRequired(true);

            builder.HasIndex(cs => cs.Year).IsUnique();

            // Population
            builder.Property(cs => cs.Population).IsRequired(false);

            // Gdp
            builder.Property(cs => cs.Gdp).IsRequired(false);

            // Primary key
            builder.HasKey(cs => new {cs.Year, cs.CountryId});

            // Relations
            builder.HasOne(cs => cs.Country)
                .WithMany(c => c.CountryStats)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
