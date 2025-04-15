using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelRecognitionConfiguration : IEntityTypeConfiguration<MilitaryPersonelRecognition>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonelRecognition> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MilitaryPersonelRecognition");

            builder.HasOne(d => d.InjunctionİdNavigation).WithMany(p => p.MilitaryPersonelRecognitions)
                .HasForeignKey(d => d.Injunctionİd)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryPersonelRecognitions)
                .HasForeignKey(d => d.PersonelId);
        }
    }

}
