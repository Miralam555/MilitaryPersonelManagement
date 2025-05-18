using Core.Entities;

namespace Entities.DTOs.MilitaryMedicalAssessmentDtos
{
    public class MilitaryMedicalAssessmentUpdateDto : IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public DateOnly AssesmentDate { get; set; }

        public string Diagnosis { get; set; } = null!;

        public string Opinion { get; set; } = null!;

        public string? Record { get; set; }
    }

}
