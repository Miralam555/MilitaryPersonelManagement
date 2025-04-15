using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class SpecialRecordConfiguration : IEntityTypeConfiguration<SpecialRecord>
    {
        public void Configure(EntityTypeBuilder<SpecialRecord> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("RecordID");

            builder.HasOne(d => d.MilitaryPersonel).WithMany(p => p.SpecialRecords)
                .HasForeignKey(d => d.MilitaryPersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
                
        }
    }

}
