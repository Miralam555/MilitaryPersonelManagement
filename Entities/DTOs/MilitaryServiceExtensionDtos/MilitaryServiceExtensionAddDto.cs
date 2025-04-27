using Core.Entities;

namespace Entities.DTOs.MilitaryServiceExtensionDtos
{
    public class MilitaryServiceExtensionAddDto:IDto
    {

        public int PersonelId { get; set; }

        public int InjunctionId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Record { get; set; }
    }

}
