using Core.DataAccess;
using Entities.DTOs.MilitaryRankDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryRankDal : IEntityRepository<MilitaryRank>
    {
        Task<List<MilitaryRankGetDto>> GetAllRanksAsync();
        Task<List<MilitaryRankGetDto>> GetAllRanksByPersonelIdAsync(int personelId);
        Task<List<MilitaryRankGetDto>> GetAllRanksByInjunctionIdAsync(int injunctionId);
        Task<MilitaryRankGetDto> GetRankByIdAsync(int id);
    }

}
