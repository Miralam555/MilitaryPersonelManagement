using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryRankConfiguration : IEntityTypeConfiguration<MilitaryRank>
    {
        public void Configure(EntityTypeBuilder<MilitaryRank> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.InjunctionId);
            
            builder.Property(e => e.RankName).HasMaxLength(30);

            

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryRanks)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Injunction).WithMany(p => p.MilitaryRanks)
                .HasForeignKey(d=>d.InjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
