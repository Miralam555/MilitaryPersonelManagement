using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class ProfessionalDevelopmentCourseConfiguration : IEntityTypeConfiguration<ProfessionalDevelopmentCourse>
    {
        public void Configure(EntityTypeBuilder<ProfessionalDevelopmentCourse> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("CourseID");
            builder.Property(e => e.CourseName).HasMaxLength(100);
            builder.Property(e => e.Duration).HasMaxLength(100);
            builder.Property(e => e.OrganizedLocation).HasMaxLength(100);
            builder.Property(e => e.Specialization).HasMaxLength(100);

            builder.HasOne(d => d.Injunction).WithMany(p => p.ProfessionalDevelopmentCourses)
                .HasForeignKey(d => d.InjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.ProfessionalDevelopmentCourses)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
