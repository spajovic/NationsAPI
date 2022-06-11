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
    public class LanguageConfiguration : BaseEntityConfiguration<Language>
    {
        public override void Configure(EntityTypeBuilder<Language> builder)
        {
            base.Configure(builder);

            // Name
            builder.Property(l => l.Name)
                .HasMaxLength(120)
                .IsRequired(true);

            builder.HasIndex(l => l.Name).IsUnique();
           
        }
    }
}
