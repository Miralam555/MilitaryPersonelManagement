using Core.DataAccess;
using Entities.DTOs.ProfessionalDevelopmentCourse;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IProfessionalDevelopmentCourseDal : IEntityRepository<ProfessionalDevelopmentCourse>
    {
        Task<ProfessionalDevelopmentCourseGetDto> GetByIdAsync(int id);
        Task<List<ProfessionalDevelopmentCourseGetDto>> GetAllCoursesByInjunctionIdAsync(int injunctionId);
        Task<List<ProfessionalDevelopmentCourseGetDto>> GetAllCoursesByPersonelIdAsync(int personelId);
        Task<List<ProfessionalDevelopmentCourseGetDto>> GetAllCoursesAsync();

    }

}
