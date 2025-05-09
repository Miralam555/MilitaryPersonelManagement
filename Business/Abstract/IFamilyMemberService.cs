using Core.Utilities.Results;
using Entities.DTOs.FamilyMemberDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface IFamilyMemberService
    {
        Task<IResult> AddFamilyMemberAsync(FamilyMemberAddDto dto);
        Task<IDataResult<List<FamilyMemberGetDto>>> GetAllFamilyMembersByPersonelIdAsync(int personelId);
        Task<IDataResult<List<FamilyMemberGetDto>>> GetAllFamilyMembersAsync();
        Task<IDataResult<FamilyMemberGetDto>> GetMemberByIdAsync(int id);
        Task<IResult> UpdateFamilyMemberAsync(FamilyMemberUpdateDto dto);
        Task<IResult> DeleteFamilyMemberAsync(int id);
    }
    

}
