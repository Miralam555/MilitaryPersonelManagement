using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryMedicalAssessmentDtos
{
    public class MedicalAssessmentPersonelGetDto
    {
        
        public string PersonelName { get; set; } = null!;
        public string PersonelSurname { get; set; } = null!;
        public MedicalAssessmentPersonelInfoGetDto MedicalAssessmentPersonelInfoGetDto { get; set; }
    }

}
