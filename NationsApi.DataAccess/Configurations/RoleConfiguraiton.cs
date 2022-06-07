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
    public class RoleConfiguraiton : BaseEntityConfiguration<Role>
    {
        public override void Configure(EntityTypeBuilder<Role> builder)
        {
            base.Configure(builder);

            // Name
            builder.Property(r => r.Name)
                .HasMaxLength(45)
                .IsRequired(true);

            builder.HasIndex(r => r.Name).IsUnique();

            //Relations
            builder.HasMany(r => r.RoleUseCases)
                .WithOne(ruc => ruc.Role)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasMany(r => r.Users)
                .WithOne(u => u.Role)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
