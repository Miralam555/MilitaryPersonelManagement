using Core.DataAccess;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryMedicalAssessmentDal : IEntityRepository<MilitaryMedicalAssessment>
    {
        Task<List<MilitaryMedicalAssessment>> GetAllAssessmentsAsync();
        Task<MilitaryMedicalAssessment> GetByIdAssessmentAsync(int id);
        Task<List<MilitaryMedicalAssessment>> GetAllAssessmentsByPersonelIdAsync(int id);
    }

}
