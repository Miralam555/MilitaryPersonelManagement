using Core.Utilities.Results;
using Entities.DTOs.BattleHistoryDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface IBattleHistoryService
    {
        Task<IDataResult<BattleHistoryGetDto>> GetHistoryByIdAsync(int id);
        Task<IDataResult<List<BattleHistoryGetDto>>> GetAllHistoriesByPersonelIdAsync(int personelId);
        Task<IDataResult<List<BattleHistoryGetDto>>> GetAllBattleHistoryAsync();

        Task<IResult> AddBattleHistoryAsync(BattleHistoryAddDto dto);
        Task<IResult> DeleteHistoryAsync(int id);
        Task<IResult> UpdateHistoryAsync(BattleHistoryUpdateDto dto);
    }
    

}
