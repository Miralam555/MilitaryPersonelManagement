using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EducationDtos
{
    public class EducationUpdateDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public string InstitutionName { get; set; } = null!;

        public DateOnly GraduationYear { get; set; }

        public string Specialization { get; set; } = null!;

        public string Degree { get; set; } = null!;

        public int EducationTypeId { get; set; }
    }
}
