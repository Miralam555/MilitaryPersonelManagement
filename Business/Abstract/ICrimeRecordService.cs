using Core.Utilities.Results;
using Entities.DTOs.CrimeRecordDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface ICrimeRecordService
    {
        Task<IDataResult<List<CrimeRecordGetDto>>> GetAllCrimeRecordsAsync();
        Task<IDataResult<List<CrimeRecordGetDto>>> GetCrimeRecordsByPersonelIdAsync(int personelId);
        Task<IDataResult<List<CrimeRecordGetDto>>> GetCrimeRecordsByMemberIdAsync(int memberId);
        Task<IDataResult<CrimeRecordGetDto>> GetCrimeRecordByIdAsync(int id);

        Task<IResult> AddCrimeRecordAsync(CrimeRecordAddDto dto);
        Task<IResult> UpdateCrimeRecordAsync(CrimeRecordUpdateDto dto);
        Task<IResult> DeleteCrimeRecordAsync(int id);
      
    }
    

}
