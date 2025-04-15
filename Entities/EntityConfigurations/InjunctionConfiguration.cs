using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class InjunctionConfiguration : IEntityTypeConfiguration<Injunction>
    {
        public void Configure(EntityTypeBuilder<Injunction> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.InjunctionIsActive).HasDefaultValue(true);
            builder .Property(e => e.InjunctionNumber).HasMaxLength(30);

            builder.HasOne(d => d.InjunctionType).WithMany(p => p.Injunctions)
                .HasForeignKey(d => d.InjunctionTypeId)
                .OnDelete(DeleteBehavior.ClientSetNull);

            builder.HasOne(d => d.IssuedByPersonel).WithMany(p => p.Injunctions)
                .HasForeignKey(d => d.IssuedByPersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
