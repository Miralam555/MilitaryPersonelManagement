using Core.DataAccess;
using Entities.DTOs.PersonelForeignLanguageLevel;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelForeignLanguageLevelDal : IEntityRepository<MilitaryPersonelForeignLanguageLevel>
    {
        Task<List<PersonelForeignLanguageLevelGetDto>> GetAllLevelAsync();
        Task<List<PersonelForeignLanguageLevelGetDto>> GetAllLevelByPersonelIdAsync(int personelId);
        Task<List<PersonelForeignLanguageLevelGetDto>> GetAllLevelByInjunctionIdAsync(int injunctionId);
        Task<PersonelForeignLanguageLevelGetDto> GetLevelByIdAsync(int id);
    }

}
