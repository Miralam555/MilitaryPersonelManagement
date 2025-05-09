using Core.Entities;

namespace Entities.DTOs.BattleHistoryDtos
{
    public class BattleHistoryGetDto:IDto
    {
        public int Id { get; set; } 

        public int? PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public string BattleName { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Position { get; set; } = null!;

        public string? InjuryOrDiseaseType { get; set; }
        public string? VeteranNote { get; set; }

    }

}
