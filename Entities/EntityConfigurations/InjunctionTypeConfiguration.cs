using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class InjunctionTypeConfiguration : IEntityTypeConfiguration<InjunctionType>
    {
        public void Configure(EntityTypeBuilder<InjunctionType> builder)
        {
            builder.HasKey(e => e.Id);
        }
    }

}
