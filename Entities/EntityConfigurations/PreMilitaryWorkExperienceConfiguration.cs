using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class PreMilitaryWorkExperienceConfiguration : IEntityTypeConfiguration<PreMilitaryWorkExperience>
    {
        public void Configure(EntityTypeBuilder<PreMilitaryWorkExperience> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("PreMilitaryWorkExperience");

            builder.Property(e => e.CompanyName).HasMaxLength(200);
            builder.Property(e => e.Position).HasMaxLength(200);

            builder.HasOne(d => d.Personel).WithMany(p => p.PreMilitaryWorkExperiences)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
