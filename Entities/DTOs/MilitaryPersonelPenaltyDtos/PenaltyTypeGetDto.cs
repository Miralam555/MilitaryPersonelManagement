using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyTypeGetDto : IDto
    {
        public string PenaltyType { get; set; } = null!;
    }
}
