using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelPenaltyConfiguration : IEntityTypeConfiguration<MilitaryPersonelPenalty>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelPenalty> builder)
        {
            builder.HasKey(e => e.Id);

            builder.HasOne(d => d.Injunction).WithMany(p => p.MilitaryPersonelPenalties)
                .HasForeignKey(d => d.InjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.PenaltyType).WithMany(p => p.MilitaryPersonelPenalties)
                .HasForeignKey(d => d.PenaltyTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryPersonelPenalties)
                .HasForeignKey(d => d.PersonelId);
        }
    }

}
