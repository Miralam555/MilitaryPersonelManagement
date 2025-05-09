using Core.DataAccess;
using Entities.DTOs.CrimeRecordDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface ICrimeRecordDal : IEntityRepository<CrimeRecord>
    {
        Task<List<CrimeRecordGetDto>> GetAllCrimeRecordsAsync();
        Task<List<CrimeRecordGetDto>> GetAllCrimeRecordsByMemberIdAsync(int memberId);
        Task<CrimeRecordGetDto> GetCrimeRecordByIdAsync(int id);
        Task<List<CrimeRecordGetDto>> GetAllCrimeRecordsByPersonelIdAsync(int personelId);
    }

}
