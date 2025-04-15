using Core.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.EntityConfigurations
{
    public class UserConfiguration : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Email).HasMaxLength(50).IsRequired();
            builder.Property(e => e.PasswordHash).HasColumnType("VARBINARY(500)").IsRequired();
            builder.Property(e => e.PasswordSalt).HasColumnType("VARBINARY(500)").IsRequired();
            builder.Property(e => e.Status).IsRequired();
        }
    }
}
