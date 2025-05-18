using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyUpdateDto:IDto
    {
        public int Id { get; set; }

        public int? PersonelId { get; set; }

        public int PenaltyTypeId { get; set; }

        public string? PenaltyDescription { get; set; }

        public string? Record { get; set; }

        public int InjunctionId { get; set; }

    }

}
