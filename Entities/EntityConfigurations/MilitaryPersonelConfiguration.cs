using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class MilitaryPersonelConfiguration : IEntityTypeConfiguration<MilitaryPersonel>
    {
        public void Configure(EntityTypeBuilder<MilitaryPersonel> builder)
        {
            builder.HasKey(e => e.Id);

            builder .Property(e => e.Id).HasColumnName("PersonelID");
            builder.Property(e => e.BirthPlace).HasMaxLength(100);
            builder.Property(e => e.Patronymic).HasMaxLength(20);
            builder.Property(e => e.PersonelName).HasMaxLength(20);
            builder.Property(e => e.PersonelSurname).HasMaxLength(20);
        }
    }

}
