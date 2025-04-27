using Core.DataAccess;
using Entities.DTOs.MilitarySkillRecordDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitarySkillRecordDal : IEntityRepository<MilitarySkillRecord>
    {
        Task<List<MilitarySkillRecordGetDto>> GetAllSkillRecordsAsync();
        Task<List<MilitarySkillRecordGetDto>> GetAllSkillRecordsByPersonelIdAsync(int personelId);
        Task<MilitarySkillRecordGetDto> GetSkillRecordByIdAsync(int id);
    }

}
