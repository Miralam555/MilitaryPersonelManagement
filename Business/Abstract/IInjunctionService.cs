using Core.Utilities.Results;
using Entities.DTOs.InjunctionDtos;

namespace Business.Abstract
{
    public interface IInjunctionService
    {
        Task<IDataResult<InjunctionUpdateAndGetDto>> GetByIdInjunctionsAsync(int id);
        Task<IDataResult<List<InjunctionUpdateAndGetDto>>> GetAllInjunctionsByIssuedPersonelIdAsync(int id);
        Task<IDataResult<List<InjunctionUpdateAndGetDto>>> GetAllInjunctionsAsync();
        Task<IResult> AddInjunctionAsync(InjunctionAddDto dto);
        Task<IResult> UpdateInjunctionAsync(InjunctionUpdateAndGetDto dto);
        Task<IResult> DeleteInjunctionAsync(int id);
    }
    

}
