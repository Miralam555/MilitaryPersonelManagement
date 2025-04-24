using Core.Entities;

namespace Entities.DTOs.PersonelReputationRiskFindingDtos
{
    public class PersonelReputationRiskFindingAddDto:IDto
    {

        public int PersonelId { get; set; }

        public string Info { get; set; } = null!;

        public string ReportingAgency { get; set; } = null!;

        public string? Record { get; set; }
    }

}
