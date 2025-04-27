using Core.Entities;

namespace Entities.DTOs.MilitaryServiceHistoryDtos
{
    public class MilitaryServiceHistoryAddDto:IDto
    {

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public int InjunctionId { get; set; }

        public string OrganizationName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string OfficialRank { get; set; } = null!;

        public bool IsCurrentMilitary { get; set; }
    }

}
