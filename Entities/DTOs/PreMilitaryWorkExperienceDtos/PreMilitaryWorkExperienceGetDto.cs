using Core.Entities;

namespace Entities.DTOs.PreMilitaryWorkExperienceDtos
{
    public class PreMilitaryWorkExperienceGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public DateOnly WorkStartDate { get; set; }

        public DateOnly WorkEndDate { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Position { get; set; } = null!;
    }
    
}
