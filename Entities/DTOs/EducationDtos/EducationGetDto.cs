using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.EducationDtos
{
    public class EducationGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;


        public string InstitutionName { get; set; } = null!;

        public DateOnly GraduationYear { get; set; }

        public string Specialization { get; set; } = null!;

        public string Degree { get; set; } = null!;

        public int EducationTypeId { get; set; }
        public string EducationTypeName { get; set; } = null!;
    }
}
