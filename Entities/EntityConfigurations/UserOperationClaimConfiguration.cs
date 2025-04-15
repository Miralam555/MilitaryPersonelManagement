using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntityConfigurations
{
    public class UserOperationClaimConfiguration : IEntityTypeConfiguration<UserOperationClaim>
    {
        public void Configure(EntityTypeBuilder<UserOperationClaim> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(e => e.User).WithMany(e => e.UserOperationClaims)
                .HasForeignKey(e => e.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(e => e.OperationClaim).WithMany(e => e.UserOperationClaims)
                .HasForeignKey(e => e.OperationClaimId)
                .OnDelete(DeleteBehavior.ClientSetNull); 
        }
    }
}
