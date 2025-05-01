using Core.Utilities.Results;
using Entities.DTOs.MilitarySkillRecordDtos;

namespace Business.Abstract
{
    public interface IMilitarySkillRecordService
    {
        Task<IDataResult<List<MilitarySkillRecordGetDto>>> GetAllRecordsAsync();
        Task<IDataResult<List<MilitarySkillRecordGetDto>>> GetAllRecordsByPersonelIdAsync(int personelId);
        Task<IDataResult<MilitarySkillRecordGetDto>> GetRecordByIdAsync(int id);
        Task<IResult> AddSkillRecordAsync(MilitarySkillRecordAddDto dto);
        Task<IResult> UpdateSkillRecordAsync(MilitarySkillRecordUpdateDto dto);
        Task<IResult> DeleteSkillRecordAsync(int id);
    }
    

}
