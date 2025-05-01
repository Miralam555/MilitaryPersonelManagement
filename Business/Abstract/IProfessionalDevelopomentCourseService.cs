using Core.Utilities.Results;
using Entities.DTOs.ProfessionalDevelopmentCourse;

namespace Business.Abstract
{
    public interface IProfessionalDevelopomentCourseService
    {
        Task<IDataResult<List<ProfessionalDevelopmentCourseGetDto>>> GetAllCoursesAsync();
        Task<IDataResult<List<ProfessionalDevelopmentCourseGetDto>>> GetAllCoursesByPersonelIdAsync(int personelId);
        Task<IDataResult<List<ProfessionalDevelopmentCourseGetDto>>> GetAllCoursesByInjunctionIdAsync(int injunctionId);
        Task<IDataResult<ProfessionalDevelopmentCourseGetDto>> GetByIdAsync(int id);
        Task<IResult> AddCourseAsync(ProfessionalDevelopmentCourseAddDto dto);
        Task<IResult> UpdateCourseAsync(ProfessionalDevelopmentCourseUpdateDto dto);
        Task<IResult> DeleteCourseAsync(int id);
    }
    

}
