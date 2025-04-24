using Core.Utilities.Results;
using Entities.DTOs.PersonelReputationRiskFindingDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelReputationRiskFindingService
    {
        Task<IDataResult<List<PersonelReputationRiskFindingGetDto>>> GetAllRisksAsync();
        Task<IDataResult<List<PersonelReputationRiskFindingGetDto>>> GetAllRisksByPersonelIdAsync(int personelId);
        Task<IDataResult<PersonelReputationRiskFindingGetDto>> GetRiskByIdAsync(int id);
        Task<IResult> AddRiskAsync(PersonelReputationRiskFindingAddDto dto);
        Task<IResult> UpdateRiskAsync(PersonelReputationRiskFindingUpdateDto dto);
        Task<IResult> DeleteRiskAsync(int id);
    }
    

}
