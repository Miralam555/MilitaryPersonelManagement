using Core.DataAccess;
using Entities.DTOs.FamilyMemberDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IFamilyMemberDal : IEntityRepository<FamilyMember>
    {
        Task<List<FamilyMemberGetDto>> GetAllMembersAsync();
        Task<List<FamilyMemberGetDto>> GetAllMembersByPersonelIdAsync(int personelId);
        Task<FamilyMemberGetDto> GetMemberByIdAsync(int id);
    }

}
