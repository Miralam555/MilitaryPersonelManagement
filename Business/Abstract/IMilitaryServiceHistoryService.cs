using Core.Utilities.Results;
using Entities.DTOs.MilitaryServiceHistoryDtos;

namespace Business.Abstract
{
    public interface IMilitaryServiceHistoryService
    {
        Task<IDataResult<List<MilitaryServiceHistoryGetDto>>> GetAllServiceHistoriesAsync();
        Task<IDataResult<List<MilitaryServiceHistoryGetDto>>> GetAllServiceHistoriesByPersonelIdAsync(int personelId);
        Task<IDataResult<List<MilitaryServiceHistoryGetDto>>> GetAllServiceHistoriesByInjunctionIdAsync(int injunctionId);
        Task<IDataResult<MilitaryServiceHistoryGetDto>> GetServiceHistoryByIdAsync(int id);
        Task<IResult> AddHistoryAsync(MilitaryServiceHistoryAddDto dto);
        Task<IResult> UpdateHistoryAsync(MilitaryServiceHistoryUpdateDto dto);
        Task<IResult> DeleteHistoryAsync(int id);
    }
    

}
