using Core.DataAccess;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelPenaltyDal : IEntityRepository<MilitaryPersonelPenalty>
    {
        Task<List<MilitaryPersonelPenalty>> GetAllPenaltiesAsync();
        Task<List<MilitaryPersonelPenalty>> GetAllPenaltiesByPersonelIdAsync(int id);
        Task<MilitaryPersonelPenalty> GetPenaltyByIdAsync(int id);
    }

}
