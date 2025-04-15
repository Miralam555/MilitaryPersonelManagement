using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelEducationConfiguration : IEntityTypeConfiguration<MilitaryPersonelEducation>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelEducation> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MilitaryPersonelEducation");

            builder.Property(e => e.Degree).HasMaxLength(50);
            builder.Property(e => e.InstitutionName).HasMaxLength(100);
            builder.Property(e => e.Specialization).HasMaxLength(100);

            builder.HasOne(d => d.EducationType).WithMany(p => p.MilitaryPersonelEducations)
                .HasForeignKey(d => d.EducationTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryPersonelEducations)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
