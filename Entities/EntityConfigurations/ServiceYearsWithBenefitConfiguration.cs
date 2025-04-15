using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class ServiceYearsWithBenefitConfiguration : IEntityTypeConfiguration<ServiceYearsWithBenefit>
    {
        public void Configure(EntityTypeBuilder<ServiceYearsWithBenefit> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("BenefitID");
            builder.Property(e => e.BenefitDocumentName).HasMaxLength(100);
            builder.Property(e => e.BenefitDocumentNumber).HasMaxLength(20);

            builder.HasOne(d => d.Personel).WithMany(p => p.ServiceYearsWithBenefits)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
