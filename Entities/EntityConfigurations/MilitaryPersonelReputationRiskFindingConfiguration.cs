using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelReputationRiskFindingConfiguration : IEntityTypeConfiguration<MilitaryPersonelReputationRiskFinding>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelReputationRiskFinding> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.ReportingAgency).HasMaxLength(100);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryPersonelReputationRiskFindings)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
