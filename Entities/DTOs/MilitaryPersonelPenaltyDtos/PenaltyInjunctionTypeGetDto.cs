using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyInjunctionTypeGetDto : IDto
    {
        public string InjunctionName { get; set; } = null!;
    }
}
