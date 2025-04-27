using Core.DataAccess;
using Entities.DTOs.MilitaryServiceExtensionDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryServiceExtensionDal : IEntityRepository<MilitaryServiceExtension>
    {
        Task<List<MilitaryServiceExtensionGetDto>> GetAllExtensionsAsync();
        Task<List<MilitaryServiceExtensionGetDto>> GetAllExtensionsByInjunctionIdAsync(int injunctionId);
        Task<List<MilitaryServiceExtensionGetDto>> GetAllExtensionsByPersonelIdAsync(int personelId);
        Task<MilitaryServiceExtensionGetDto> GetExtensionByIdAsync(int id);
    }

}
