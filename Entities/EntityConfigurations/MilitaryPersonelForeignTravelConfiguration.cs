using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelForeignTravelConfiguration : IEntityTypeConfiguration<MilitaryPersonelForeignTravel>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelForeignTravel> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.TravellingCountryName).HasMaxLength(40);

            builder.HasOne(d => d.Injunction).WithMany(p => p.MilitaryPersonelForeignTravels)
                .HasForeignKey(d => d.InjunctionId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryPersonelForeignTravels)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
