using Core.Entities;

namespace Entities.DTOs.PreMilitaryWorkExperienceDtos
{
    public class PreMilitaryWorkExperienceAddDto:IDto
    {

        public int PersonelId { get; set; }

        public DateOnly WorkStartDate { get; set; }

        public DateOnly WorkEndDate { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Position { get; set; } = null!;
    }
    
}
