using Core.Utilities.Results;
using Entities.DTOs.MilitaryServiceExtensionDtos;

namespace Business.Abstract
{
    public interface IMilitaryServiceExtensionService
    {
        Task<IDataResult<List<MilitaryServiceExtensionGetDto>>> GetAllExtensionsAsync();
        Task<IDataResult<List<MilitaryServiceExtensionGetDto>>> GetAllExtensionsByPersonelIdAsync(int personelId);
        Task<IDataResult<List<MilitaryServiceExtensionGetDto>>> GetAllExtensionsByInjunctionIdAsync(int injunctionId);
        Task<IDataResult<MilitaryServiceExtensionGetDto>> GetExtensionByIdAsync(int id);
        Task<IResult> AddExtensionASync(MilitaryServiceExtensionAddDto dto);
        Task<IResult> UpdateExtensionAsync(MilitaryServiceExtensionUpdateDto dto);
        Task<IResult> DeleteExtensionAsync(int id);
    }
    

}
