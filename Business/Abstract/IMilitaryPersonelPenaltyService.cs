using Core.Utilities.Results;
using Entities.DTOs.MilitaryPersonelPenaltyDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelPenaltyService
    {
        Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesAsync();
        Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesByPersonelIdAsync(int personelId);
        Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesByPenaltyTypeIdAsync(int penaltyTypeId);
        Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesByInjunctiondAsync(int injunctionId);
        Task<IDataResult<PenaltyGetDto>> GetPenaltyByIdAsync(int id);
        Task<IResult> AddPenaltyAsync(PenaltyAddDto dto);
        Task<IResult> UpdatePenaltyAsync(PenaltyUpdateDto dto);
        Task<IResult> DeletePenaltyAsync(int id);
    }
    

}
