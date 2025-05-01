using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PreMilitaryWorkExperienceDtos
{
    public class PreMilitaryWorkExperienceUpdateDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public DateOnly WorkStartDate { get; set; }

        public DateOnly WorkEndDate { get; set; }

        public string CompanyName { get; set; } = null!;

        public string Position { get; set; } = null!;
    }
    
}
