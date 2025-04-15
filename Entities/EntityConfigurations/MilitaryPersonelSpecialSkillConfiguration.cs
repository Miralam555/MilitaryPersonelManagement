using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelSpecialSkillConfiguration : IEntityTypeConfiguration<MilitaryPersonelSpecialSkill>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelSpecialSkill> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryPersonelSpecialSkills)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
