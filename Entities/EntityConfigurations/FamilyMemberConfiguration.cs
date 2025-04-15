using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MyMilitaryFinalProject.Entities.Concrete;
namespace MyMilitaryFinalProject.EntityConfigurations
{
    public class FamilyMemberConfiguration : IEntityTypeConfiguration<FamilyMember>
    {
        public void Configure(EntityTypeBuilder<FamilyMember> builder)
        {
            builder.HasKey(e => e.Id);

            builder.Property(e => e.Id).HasColumnName("MemberID");
            builder.Property(e => e.BirthPlace).HasMaxLength(20);
            builder.Property(e => e.MemberName).HasMaxLength(20);
            builder.Property(e => e.MemberPatronymic).HasMaxLength(20);
            builder.Property(e => e.MemberSurName).HasMaxLength(20);
            builder.Property(e => e.RelationShip).HasMaxLength(30);

            builder.HasOne(d => d.Personel).WithMany(p => p.FamilyMembers)
                .HasForeignKey(d => d.PersonelId)
                .OnDelete(DeleteBehavior.ClientSetNull);
        }
    }

}
