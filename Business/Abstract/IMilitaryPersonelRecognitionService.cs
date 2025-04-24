using Core.Utilities.Results;
using Entities.DTOs.MilitaryPersonelRecognitionDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelRecognitionService
    {
        Task<IResult> DeleteRecognitionAsync(int id);
        Task<IResult> UpdateRecognitionAsync(PersonelRecognitionUpdateDto dto);
        Task<IResult> AddRecognitionAsync(PersonelRecognitionAddDto dto);
        Task<IDataResult<PersonelRecognitionGetDto>> GetRecognitionByIdAsync(int id); Task<IDataResult<List<PersonelRecognitionGetDto>>> GetAllRecognitionsByPersonelIdAsync(int personelId);
        Task<IDataResult<List<PersonelRecognitionGetDto>>> GetAllRecognitionsByInjunctionIdAsync(int injunctionID);
        Task<IDataResult<List<PersonelRecognitionGetDto>>> GetAllRecognitionsAsync();

    }


}
