using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class EducationTypeConfiguration : IEntityTypeConfiguration<EducationType>
    {
        public void Configure(EntityTypeBuilder<EducationType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.EducationTypeName)
                .HasMaxLength(20)
                .HasColumnName("EducationType");
        }
    }

}
