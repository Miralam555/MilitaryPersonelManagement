using Core.DataAccess;
using Entities.DTOs.FamilyMemberForeignTravelDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelFamilyMemberForeignTravelDal : IEntityRepository<MilitaryPersonelFamilyMemberForeignTravel>
    {
        Task<FamilyMemberForeignTravelGetDto> GetTravelByIdAsync(int id);
        Task<List<FamilyMemberForeignTravelGetDto>> GetAllTravelsByMemberIdAsync(int memberId);
        Task<List<FamilyMemberForeignTravelGetDto>> GetAllTravelsAsync();
    }

}
