using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryMedicalAssesmentConfiguration : IEntityTypeConfiguration<MilitaryMedicalAssessment>
    {
        public void Configure(EntityTypeBuilder<MilitaryMedicalAssessment> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Diagnosis).HasMaxLength(300);
            builder.Property(e => e.Opinion).HasMaxLength(200);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryMedicalAssessments)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
