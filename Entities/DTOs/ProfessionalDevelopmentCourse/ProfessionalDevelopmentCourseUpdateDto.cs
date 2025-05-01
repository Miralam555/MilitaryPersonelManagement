using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.ProfessionalDevelopmentCourse
{
    public class ProfessionalDevelopmentCourseUpdateDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public int InjunctionId { get; set; }

        public string OrganizedLocation { get; set; } = null!;

        public string CourseName { get; set; } = null!;

        public string Specialization { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public string Duration { get; set; } = null!;

        public bool IsCurrentMilitary { get; set; }
    }

}
