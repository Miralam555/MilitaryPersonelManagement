using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryServiceHistoryConfiguration : IEntityTypeConfiguration<MilitaryServiceHistory>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceHistory> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MilitaryServiceHistories");

            
            
            builder.Property(e => e.OfficialRank).HasMaxLength(40);
            builder.Property(e => e.Position).HasMaxLength(40);
            builder.Property(e => e.OrganizationName).HasMaxLength(40);

            builder.HasOne(d => d.Injunction).WithOne(p => p.MilitaryServiceHistory)
                .HasForeignKey<MilitaryServiceHistory>(d => d.InjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryServiceHistories)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
