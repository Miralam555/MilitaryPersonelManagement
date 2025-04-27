using Core.DataAccess;
using Entities.DTOs.MilitaryServiceHistoryDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryServiceHistoryDal : IEntityRepository<MilitaryServiceHistory>
    {
        Task<List<MilitaryServiceHistoryGetDto>> GetAllServiceHistoryAsync();
        Task<List<MilitaryServiceHistoryGetDto>> GetAllServiceHistoryByPersonelIdAsync(int personelId);
        Task<List<MilitaryServiceHistoryGetDto>> GetAllServiceHistoryByInjunctionIdAsync(int injunctionId);
        Task<MilitaryServiceHistoryGetDto> GetServiceHistoryByIdAsync(int id);
    }

}
