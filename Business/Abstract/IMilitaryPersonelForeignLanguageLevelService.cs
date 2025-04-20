using Core.Utilities.Results;
using Entities.DTOs.PersonelForeignLanguageLevel;

namespace Business.Abstract
{
    public interface IMilitaryPersonelForeignLanguageLevelService
    {
        Task<IDataResult<List<PersonelForeignLanguageLevelGetDto>>> GetAllLevelAsync();
        Task<IDataResult<List<PersonelForeignLanguageLevelGetDto>>> GetAllLevelByInjunctionIdAsync(int injunctionId);
        Task<IDataResult<List<PersonelForeignLanguageLevelGetDto>>> GetAllLevelByPersonelIdAsync(int personelId);
        Task<IDataResult<PersonelForeignLanguageLevelGetDto>> GetLevelByIdAsync(int id);
        Task<IResult> AddLevelAsync(PersonelForeignLanguageLevelAddDto dto);
        Task<IResult> UpdateLevelAsync(PersonelForeignLanguageLevelUpdateDto dto);
        Task<IResult> DeleteAsync(int id);
    }
    

}
