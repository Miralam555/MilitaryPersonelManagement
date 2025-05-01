using Core.Entities;

namespace Entities.DTOs.ProfessionalDevelopmentCourse
{
    public class ProfessionalDevelopmentCourseGetDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public int InjunctionId { get; set; }
        public string InjunctionNumber { get; set; } = null!;

        public string OrganizedLocation { get; set; } = null!;

        public string CourseName { get; set; } = null!;

        public string Specialization { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public string Duration { get; set; } = null!;

        public bool IsCurrentMilitary { get; set; }
    }

}
