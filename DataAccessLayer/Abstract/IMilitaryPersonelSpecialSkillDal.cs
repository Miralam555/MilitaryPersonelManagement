using Core.DataAccess;
using Entities.DTOs.PersonelSpecialSkillDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelSpecialSkillDal : IEntityRepository<MilitaryPersonelSpecialSkill>
    {
        Task<List<PersonelSpecialSkillGetDto>> GetAllSkillsAsync();
        Task<List<PersonelSpecialSkillGetDto>> GetAllSkillsByPersonelIdAsync(int personelId);
        Task<PersonelSpecialSkillGetDto> GetSkillByIdAsync(int id);
    }

}
