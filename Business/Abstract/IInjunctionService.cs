using Core.Utilities.Results;
using Entities.DTOs.InjunctionDtos;

namespace Business.Abstract
{
    public interface IInjunctionService
    {
        Task<IDataResult<InjunctionGetDto>> GetInjunctionByIdAsync(int id);
        Task<IDataResult<List<InjunctionGetDto>>> GetAllInjunctionsByIssuedPersonelIdAsync(int personelId);
        Task<IDataResult<List<InjunctionGetDto>>> GetAllInjunctionsAsync();
        Task<IResult> AddInjunctionAsync(InjunctionAddDto dto);
        Task<IResult> UpdateInjunctionAsync(InjunctionUpdateDto dto);
        Task<IResult> DeleteInjunctionAsync(int id);
    }
    

}
