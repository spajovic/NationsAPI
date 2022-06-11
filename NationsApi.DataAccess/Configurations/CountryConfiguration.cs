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
    public class CountryConfiguration : BaseEntityConfiguration<Country>
    {
        public override void Configure(EntityTypeBuilder<Country> builder)
        {
            base.Configure(builder);

            // Name
            builder.Property(c => c.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            builder.HasIndex(c => c.Name).IsUnique();

            // Area
            builder.Property(c => c.Area).IsRequired(true);

            // National Day
            builder.Property(c => c.NationalDay).IsRequired(false);

            // Country Code
            builder.Property(c => c.CountryCode)
                .HasMaxLength(5)
                .IsRequired(true);

            builder.HasIndex(c => c.CountryCode).IsUnique();

            // Relations

            builder.HasMany(c => c.CountryStats)
                .WithOne(cs => cs.Country)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.Region)
                .WithMany(r => r.Countries)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(c => c.User)
                .WithMany(u => u.Countries)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(c => c.CountryFlags)
                .WithOne(cf => cf.Country)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
