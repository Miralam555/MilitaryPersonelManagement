using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelInfoConfiguration : IEntityTypeConfiguration<MilitaryPersonelInfo>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelInfo> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasIndex(e => e.Pin).IsUnique();
            builder.HasIndex(e => e.IdentityCardNumber).IsUnique();

            builder.Property(e => e.BloodGroup).HasMaxLength(10);
            builder.Property(e => e.Height).HasMaxLength(10);
            builder.Property(e => e.IdentityCardNumber).HasMaxLength(9);
            builder.Property(e => e.Nationality).HasMaxLength(200);
            builder.Property(e => e.Pin)
                .HasMaxLength(7)
                .HasColumnName("PIN");
            builder.Property(e => e.Weight).HasMaxLength(10);

            builder.HasOne(d => d.MaritalStatus).WithMany(p => p.MilitaryPersonelInfos)
                .HasForeignKey(d => d.MaritalStatusId);

            builder.HasOne(d => d.Personel).WithOne(p => p.MilitaryPersonelInfo)
                .HasForeignKey<MilitaryPersonelInfo>(d => d.Id)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }

}
