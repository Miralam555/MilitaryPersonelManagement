using Core.Utilities.Results;
using Entities.DTOs.CrimeRecordDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface ICrimeRecordService
    {
        Task<IDataResult<List<CrimeRecordUpdateAndGetDto>>> GetAllCrimeRecordsAsync();
        Task<IResult> AddCrimeRecordAsync(CrimeRecordAddDto dto);
        Task<IResult> UpdateCrimeRecordAsync(CrimeRecordUpdateAndGetDto dto);
        Task<IResult> DeleteCrimeRecordAsync(int id);
        Task<IDataResult<List<CrimeRecordUpdateAndGetDto>>> GetCrimeRecordsByPersonelIdAsync(int id);
        Task<IDataResult<List<CrimeRecordUpdateAndGetDto>>> GetCrimeRecordsByMemberIdAsync(int id);
    }
    

}
