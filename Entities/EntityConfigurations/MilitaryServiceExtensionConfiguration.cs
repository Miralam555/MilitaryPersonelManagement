using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryServiceExtensionConfiguration : IEntityTypeConfiguration<MilitaryServiceExtension>
    {
        public void Configure(EntityTypeBuilder<MilitaryServiceExtension> builder)
        {
            builder.HasKey(e => e.Id);

            builder.ToTable("MilitaryServiceExtension");

            builder.Property(e => e.Id).HasColumnName("ExtensionID");

            builder.HasOne(d => d.Injunction).WithMany(p => p.MilitaryServiceExtensions)
               .HasForeignKey(d => d.InjunctionId)
               .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.Personel).WithMany(p => p.MilitaryServiceExtensions)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
