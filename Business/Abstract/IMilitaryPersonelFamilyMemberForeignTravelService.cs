using Core.Utilities.Results;
using Entities.DTOs.FamilyMemberForeignTravelDtos;

namespace Business.Abstract
{
    public interface IMilitaryPersonelFamilyMemberForeignTravelService
    {
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateTravelAsync(FamilyMemberForeignTraveUpdateDto dto);
        Task<IResult> AddTravelAsync(FamilyMemberForeignTravelAddDto dto);
        Task<IDataResult<List<FamilyMemberForeignTravelGetDto>>> GetAllByMemberIdAsync(int memberId);
        Task<IDataResult<List<FamilyMemberForeignTravelGetDto>>> GetAllTravelsAsync();
        Task<IDataResult<FamilyMemberForeignTravelGetDto>> GetByIdAsync(int id);
    }
    

}
