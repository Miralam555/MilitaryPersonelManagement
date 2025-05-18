using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyAddDto:IDto
    {
        public int? PersonelId { get; set; }

        public int PenaltyTypeId { get; set; }

        public string? PenaltyDescription { get; set; }

        public string? Record { get; set; }

        public int InjunctionId { get; set; }

    }

}
