using Core.Utilities.Results;
using Entities.DTOs.BattleHistoryDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface IBattleHistoryService
    {
        Task<IDataResult<List<BattleHistoryUpdateAndGetDto>>> GetAllHistoryByPersonelIdAsync(int id);
        Task<IResult> AddBattleHistoryAsync(BattleHistoryAddDto dto);
        Task<IResult> GetByIdAsync(int id);
        //Task<IResult> UpdateHistoryAsync(BattleHistoryUpdateAndGetDto dto);
        Task<IResult> DeleteHistoryAsync(int id);
        Task<IDataResult<List<BattleHistoryUpdateAndGetDto>>> GetAllBattleHistoryAsync();
        Task<IResult> UpdateHistoryAsync(BattleHistoryUpdateAndGetDto dto);
    }
    

}
