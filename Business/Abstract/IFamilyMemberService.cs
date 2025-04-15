using Core.Utilities.Results;
using Entities.DTOs.FamilyMemberDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface IFamilyMemberService
    {
        Task<IResult> AddFamilyMemberAsync(FamilyMemberAddDto dto);
        Task<IDataResult<List<FamilyMemberUpdateAndGetDto>>> GetAllFamilyMembersAsync();
        Task<IDataResult<List<FamilyMemberUpdateAndGetDto>>> GetAllFamilyMembersByPersonelIdAsync(int id);
        Task<IResult> UpdateFamilyMemberAsync(FamilyMemberUpdateAndGetDto dto);
        Task<IResult> DeleteFamilyMemberAsync(int id);
    }
    

}
