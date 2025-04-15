using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyInjunctionGetDto : IDto
    {
        public string InjunctionNumber { get; set; } = null!;

        public DateOnly InjuctionStartDate { get; set; }

        public bool? InjunctionIsActive { get; set; }


        public int IssuedByPersonelId { get; set; }
        public PenaltyInjunctionTypeGetDto PenaltyInjunctionTypeGetDto { get; set; }
    }
}
