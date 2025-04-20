using Core.Utilities.Results;
using Entities.DTOs.EducationDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelEducationService
    {
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(EducationUpdateDto dto);
        Task<IResult> AddAsync(EducationAddDto dto);
        Task<IDataResult<EducationGetDto>> GetByIdAsync(int id);
        Task<IDataResult<List<EducationGetDto>>> GetAllByPersonelIdAsync(int personelId);
        Task<IDataResult<List<EducationGetDto>>> GetAllEducationAsync();
    }
    

}
