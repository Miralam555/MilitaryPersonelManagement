using Core.Entities;

namespace Entities.DTOs.MilitaryMedicalAssessmentDtos
{
    public class MilitaryMedicalAssessmentGetDto : IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public DateOnly AssesmentDate { get; set; }

        public string Diagnosis { get; set; } = null!;

        public string Opinion { get; set; } = null!;

        public string? Record { get; set; }
    }

}
