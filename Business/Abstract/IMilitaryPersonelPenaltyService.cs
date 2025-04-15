using Core.Utilities.Results;
using Entities.DTOs.MilitaryPersonelPenaltyDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelPenaltyService
    {
        Task<IDataResult<List<PenaltyGetDto>>> GetAllPenaltiesAsync();
    }
    

}
