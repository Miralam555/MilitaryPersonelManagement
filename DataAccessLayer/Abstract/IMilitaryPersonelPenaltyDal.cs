using Core.DataAccess;
using Entities.DTOs.MilitaryPersonelPenaltyDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelPenaltyDal : IEntityRepository<MilitaryPersonelPenalty>
    {
        Task<List<PenaltyGetDto>> GetAllPenaltiesAsync();
        Task<List<PenaltyGetDto>> GetAllPenaltiesByPersonelIdAsync(int personelId);
        Task<List<PenaltyGetDto>> GetAllPenaltiesByPenaltyTypeIdAsync(int penaltyTypeId);
        Task<List<PenaltyGetDto>> GetAllPenaltiesByInjunctionIdAsync(int injunctionId);
        Task<PenaltyGetDto> GetPenaltyByIdAsync(int id);
    }

}
