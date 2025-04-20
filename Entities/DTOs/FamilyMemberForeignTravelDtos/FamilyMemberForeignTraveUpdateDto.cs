using Core.Entities;

namespace Entities.DTOs.FamilyMemberForeignTravelDtos
{
    public class FamilyMemberForeignTraveUpdateDto : IDto
    {
        public int Id { get; set; }

        public int MemberId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string TravellingCountryName { get; set; } = null!;

        public string? TravelReason { get; set; }

        public string? Record { get; set; }

    }
}
