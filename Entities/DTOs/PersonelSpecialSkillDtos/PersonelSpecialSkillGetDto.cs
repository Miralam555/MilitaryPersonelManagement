using Core.Entities;

namespace Entities.DTOs.PersonelSpecialSkillDtos
{
    public class PersonelSpecialSkillGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public string? Skill { get; set; }
    }

}
