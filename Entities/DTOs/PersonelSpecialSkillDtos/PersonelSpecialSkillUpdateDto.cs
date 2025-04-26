using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PersonelSpecialSkillDtos
{
    public class PersonelSpecialSkillUpdateDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public string? Skill { get; set; }
    }

}
