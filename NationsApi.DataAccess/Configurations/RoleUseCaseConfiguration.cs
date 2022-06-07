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
    public class RoleUseCaseConfiguration : IEntityTypeConfiguration<RoleUseCase>
    {
        public void Configure(EntityTypeBuilder<RoleUseCase> builder)
        {
            // Primary keys
            builder.HasKey(rlc => new { rlc.RoleId, rlc.UseCaseId });

            //Relation
            builder.HasOne(rlc => rlc.Role)
                .WithMany(r => r.RoleUseCases)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
