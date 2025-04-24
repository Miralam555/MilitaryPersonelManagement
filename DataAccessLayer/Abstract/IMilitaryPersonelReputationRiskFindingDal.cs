using Core.DataAccess;
using Entities.DTOs.PersonelReputationRiskFindingDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelReputationRiskFindingDal : IEntityRepository<MilitaryPersonelReputationRiskFinding>
    {
        Task<List<PersonelReputationRiskFindingGetDto>> GetAllReportsAsync();
        Task<List<PersonelReputationRiskFindingGetDto>> GetAllReportsByPerosnelIdAsync(int personelId);
        Task<PersonelReputationRiskFindingGetDto> GetReportAsync(int id);
    }

}
