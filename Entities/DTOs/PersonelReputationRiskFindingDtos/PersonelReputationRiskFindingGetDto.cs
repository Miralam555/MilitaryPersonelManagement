using Core.Entities;

namespace Entities.DTOs.PersonelReputationRiskFindingDtos
{
    public class PersonelReputationRiskFindingGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public string Info { get; set; } = null!;

        public string ReportingAgency { get; set; } = null!;

        public string? Record { get; set; }
    }

}
