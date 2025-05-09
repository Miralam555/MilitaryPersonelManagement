using Core.Entities;

namespace Entities.DTOs.FamilyMembersInServiceDtos
{
    public class FamilyMembersInServiceGetDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }

        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public int? MemberId { get; set; }
        public string MemberName { get; set; } = null!;

        public string MemberSurName { get; set; } = null!;

        public string? Record { get; set; }
    }

}
