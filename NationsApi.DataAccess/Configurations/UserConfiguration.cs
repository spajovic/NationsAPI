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
    public class UserConfiguration : BaseEntityConfiguration<User>
    {
        public override void Configure(EntityTypeBuilder<User> builder)
        {
            base.Configure(builder);

            // First Name
            builder.Property(u => u.FirstName)
                .HasMaxLength(45)
                .IsRequired(true);

            // Last Name
            builder.Property(u => u.LastName)
                .HasMaxLength(50)
                .IsRequired(true);

            // Email
            builder.Property(u => u.Email).IsRequired(true);
            builder.HasIndex(u => u.Email).IsUnique();

            // Password
            builder.Property(u => u.Password).IsRequired(true);

            // Relations
            builder.HasMany(u => u.Countries)
                .WithOne(c => c.User)
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(u => u.Role)
                .WithMany(r => r.Users)
                .OnDelete(DeleteBehavior.Restrict);

        }
    }
}
