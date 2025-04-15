using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelFamilyMemberForeignTravelConfiguration : IEntityTypeConfiguration<MilitaryPersonelFamilyMemberForeignTravel>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelFamilyMemberForeignTravel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MilitaryPersonelFamilyMemberForeignTravel");

            builder.Property(e => e.TravellingCountryName).HasMaxLength(40);

            builder.HasOne(d => d.Member).WithMany(p => p.MilitaryPersonelFamilyMemberForeignTravels)
                .HasForeignKey(d => d.MemberId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
