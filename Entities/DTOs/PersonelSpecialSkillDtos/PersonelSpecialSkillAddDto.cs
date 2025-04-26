using Core.Entities;

namespace Entities.DTOs.PersonelSpecialSkillDtos
{
    public class PersonelSpecialSkillAddDto:IDto
    {
       

        public int PersonelId { get; set; }

        public string? Skill { get; set; }
    }

}
