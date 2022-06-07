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
    public class ContinentConfiguration : BaseEntityConfiguration<Continent>
    {
        public override void Configure(EntityTypeBuilder<Continent> builder)
        {
            base.Configure(builder);

            builder.Property(x => x.Name)
                .HasMaxLength(50)
                .IsRequired(true);

            // Relations
            builder.HasMany(c => c.Regions)
                .WithOne(r => r.Continent)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
