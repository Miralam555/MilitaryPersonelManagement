using Core.Utilities.Results;
using Entities.DTOs.PersonelSpecialSkillDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelSpecialSkillService
    {
        Task<IDataResult<List<PersonelSpecialSkillGetDto>>> GetAllSkillsAsync();
        Task<IDataResult<List<PersonelSpecialSkillGetDto>>> GetAllSkillsByPersonelIdAsync(int personelId);
        Task<IDataResult<PersonelSpecialSkillGetDto>> GetSkillByIdAsync(int id);
        Task<IResult> AddSkillAsync(PersonelSpecialSkillAddDto dto);
        Task<IResult> UpdateSkillAsync(PersonelSpecialSkillUpdateDto dto);
        Task<IResult> DeleteSkillAsync(int id);
    }
    

}
