using Core.DataAccess;
using Entities.DTOs.BattleHistoryDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IBattleHistoryDal : IEntityRepository<BattleHistory>
    {
        Task<List<BattleHistoryGetDto>> GetAllHistoriesAsync();
        Task<List<BattleHistoryGetDto>> GetAllHistoriesByPersonelIdAsync(int personelId);
        Task<BattleHistoryGetDto> GetHistoryByIdAsync(int id);
    }

}
