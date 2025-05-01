using Core.Utilities.Results;
using Entities.DTOs.PreMilitaryWorkExperienceDtos;

namespace Business.Abstract
{
    public interface IPreMilitaryWorkExperienceService
    {
        Task<IDataResult<List<PreMilitaryWorkExperienceGetDto>>> GetAllExperiencesAsync();
        Task<IDataResult<List<PreMilitaryWorkExperienceGetDto>>> GetAllExperiencesByPersonelIdAsync(int personelId);
        Task<IDataResult<PreMilitaryWorkExperienceGetDto>> GetExperienceByIdAsync(int id);
        Task<IResult> AddExperienceAsync(PreMilitaryWorkExperienceAddDto dto);
        Task<IResult> UpdateExperienceAsync(PreMilitaryWorkExperienceUpdateDto dto);
        Task<IResult> DeleteExperienceAsync(int id);
    }
    

}
