using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelForeignLanguageLevelConfiguration : IEntityTypeConfiguration<MilitaryPersonelForeignLanguageLevel>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelForeignLanguageLevel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.LanguageLevel).HasMaxLength(30);
            builder.Property(e => e.LanguageName).HasMaxLength(20);

            builder.HasOne(d => d.AllowanceInjunction).WithMany(p => p.MilitaryPersonelForeignLanguageLevels)
                .HasForeignKey(d => d.AllowanceInjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryPersonelForeignLanguageLevels)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
