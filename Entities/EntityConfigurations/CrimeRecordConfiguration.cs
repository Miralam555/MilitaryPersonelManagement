using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class CrimeRecordConfiguration : IEntityTypeConfiguration<CrimeRecord>
    {
        public void Configure(EntityTypeBuilder<CrimeRecord> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ChargeDuration).HasMaxLength(50);
            builder.Property(e => e.PenalInstitution).HasMaxLength(100);

            builder.HasOne(d => d.Member).WithMany(p => p.CrimeRecords)
            .HasForeignKey(d => d.MemberId);

            builder.HasOne(d => d.Personel).WithMany(p => p.CrimeRecords)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
