using Core.Entities;

namespace Entities.DTOs.MilitaryServiceExtensionDtos
{
    public class MilitaryServiceExtensionGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;
        public int InjunctionId { get; set; }
        public string InjunctionNumber { get; set; } = null!;
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Record { get; set; }
    }

}
