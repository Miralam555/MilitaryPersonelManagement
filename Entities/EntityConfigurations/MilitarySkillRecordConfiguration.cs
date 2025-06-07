using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitarySkillRecordConfiguration : IEntityTypeConfiguration<MilitarySkillRecord>
    {
        public void Configure(EntityTypeBuilder<MilitarySkillRecord> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id);
            
            builder.Property(e => e.SkillDegree).HasMaxLength(20);

            builder.HasOne(d => d.Injunction).WithOne(p => p.MilitarySkillRecord)
                .HasForeignKey<MilitarySkillRecord>(d => d.IssuedByInjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
            builder.HasOne(d => d.Injunction).WithOne(p => p.MilitarySkillRecord)
                .HasForeignKey<MilitarySkillRecord>(d => d.ApprovedByInjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitarySkillRecords)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
