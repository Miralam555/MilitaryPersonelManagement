using Core.Entities;

namespace Entities.DTOs.FamilyMemberDtos
{
    public class FamilyMemberGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public string RelationShip { get; set; } = null!;

        public string MemberName { get; set; } = null!;

        public string MemberSurName { get; set; } = null!;

        public string MemberPatronymic { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string BirthPlace { get; set; } = null!;

        public string Occupation { get; set; } = null!;
    }

}
