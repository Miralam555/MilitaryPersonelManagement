using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPenaltyTypeConfiguration : IEntityTypeConfiguration<MilitaryPenaltyType>
    {
        public void Configure(EntityTypeBuilder<MilitaryPenaltyType> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.PenaltyType).HasMaxLength(100);
        }
    }

}
