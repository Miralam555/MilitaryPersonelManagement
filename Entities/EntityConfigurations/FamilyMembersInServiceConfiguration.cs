using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class FamilyMembersInServiceConfiguration : IEntityTypeConfiguration<FamilyMembersInService>
    {
        public void Configure(EntityTypeBuilder<FamilyMembersInService> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("FamilyMembersInService");

            builder.HasOne(d => d.Member).WithMany(p => p.FamilyMembersInServices)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.FamilyMembersInServices)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
