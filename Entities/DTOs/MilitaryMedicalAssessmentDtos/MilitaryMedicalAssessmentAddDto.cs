using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryMedicalAssessmentDtos
{
    public class MilitaryMedicalAssessmentAddDto:IDto
    {
        public int PersonelId { get; set; }

        public DateOnly AssesmentDate { get; set; }

        public string Diagnosis { get; set; } = null!;

        public string Opinion { get; set; } = null!;

        public string? Record { get; set; }
    }
}
