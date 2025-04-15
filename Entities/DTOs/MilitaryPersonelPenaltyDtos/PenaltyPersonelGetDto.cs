using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyPersonelGetDto : IDto
    {
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;
    }
}
