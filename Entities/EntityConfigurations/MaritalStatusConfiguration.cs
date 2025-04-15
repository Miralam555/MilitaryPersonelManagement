using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MaritalStatusConfiguration : IEntityTypeConfiguration<MaritalStatus>
    {
        public void Configure(EntityTypeBuilder<MaritalStatus> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MaritalStatus");

            builder.Property(e => e.Id).HasColumnName("StatusID");
            builder.Property(e => e.StatusName)
                .HasMaxLength(20);
            builder.HasIndex(e => e.StatusName).IsUnique();    
        }
    }

}
