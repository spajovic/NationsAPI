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
    public class UseCaseLogConfiguration : IEntityTypeConfiguration<UseCaseLog>
    {
        public void Configure(EntityTypeBuilder<UseCaseLog> builder)
        {
            // Use Case Name
            builder.Property(ucl => ucl.UseCaseName).IsRequired(true);
            builder.HasIndex(ucl => ucl.UseCaseName).IsUnique();

            // Date
            builder.Property(ucl => ucl.Date).IsRequired(true);

            // Actor
            builder.Property(ucl => ucl.Actor).IsRequired(true);

            // Date
            builder.Property(ucl => ucl.Date).IsRequired(true);
        }
    }
}
