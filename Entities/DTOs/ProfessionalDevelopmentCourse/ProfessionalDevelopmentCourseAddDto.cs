using Core.Entities;

namespace Entities.DTOs.ProfessionalDevelopmentCourse
{
    public class ProfessionalDevelopmentCourseAddDto:IDto
    {

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
