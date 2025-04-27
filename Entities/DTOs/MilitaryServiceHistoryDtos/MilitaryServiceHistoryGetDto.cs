using Core.Entities;

namespace Entities.DTOs.MilitaryServiceHistoryDtos
{
    public class MilitaryServiceHistoryGetDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public int InjunctionId { get; set; }
        public string InjunctionNumber { get; set; } = null!;

        public string OrganizationName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string OfficialRank { get; set; } = null!;

        public bool IsCurrentMilitary { get; set; }
    }

}
