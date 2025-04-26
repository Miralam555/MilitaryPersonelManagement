using Core.Utilities.Results;
using Entities.DTOs.MilitaryRankDtos;

namespace Business.Abstract
{
    public interface IMilitaryRankService
    {
        Task<IDataResult<List<MilitaryRankGetDto>>> GetAllRanksAsync();
        Task<IDataResult<List<MilitaryRankGetDto>>> GetAllRanksByPersonelIdAsync(int personelId);
        Task<IDataResult<List<MilitaryRankGetDto>>> GetAllRanksByInjunctionIdAsync(int injunctionId);
        Task<IDataResult<MilitaryRankGetDto>> GetRankByIdAsync(int id);
        Task<IResult> AddRankAsync(MilitaryRankAddDto dto);
        Task<IResult> UpdateRankAsync(MilitaryRankUpdateDto dto);
        Task<IResult> DeleteRankAsync(int id);
    }
    

}
