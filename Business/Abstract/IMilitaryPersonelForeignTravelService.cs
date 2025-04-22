using Core.Utilities.Results;
using Entities.DTOs.PersonelForeignTravelDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelForeignTravelService
    {
        Task<IDataResult<List<PersonelForeignTravelGetDto>>> GetAllTravelsAsync();
        Task<IDataResult<List<PersonelForeignTravelGetDto>>> GetAllTravelsByInjunctionIdAsync(int injunctionId);
        Task<IDataResult<List<PersonelForeignTravelGetDto>>> GetAllTravelsByPersonelIdAsync(int personelId);
        Task<IDataResult<PersonelForeignTravelGetDto>> GetByIdAsync(int id);
        Task<IResult> AddTravelAsync(PersonelForeignTravelAddDto dto);
       Task<IResult> DeleteTravelAsync(int id);
        Task<IResult> UpdateTravelAsync(PersonelForeignTravelUpdateDto dto);
    }
    

}
