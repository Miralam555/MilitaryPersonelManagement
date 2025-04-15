using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
using System.Reflection.Emit;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class BattleHistoryConfiguration : IEntityTypeConfiguration<BattleHistory>
    {
        public void Configure(EntityTypeBuilder<BattleHistory> builder)
        {

            builder.HasKey(e => e.Id);

            builder.ToTable("BattleHistory");

            builder.Property(e => e.Id).HasColumnName("BattleID");
            builder.Property(e => e.Position).HasMaxLength(100);

            builder.HasOne(d => d.Personel).WithMany(p => p.BattleHistories)
                .HasForeignKey(d => d.PersonelId);

        }
    }

}
