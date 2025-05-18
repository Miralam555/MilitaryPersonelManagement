using Core.DataAccess;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryMedicalAssessmentDal : IEntityRepository<MilitaryMedicalAssessment>
    {
        Task<List<MilitaryMedicalAssessmentGetDto>> GetAllAssessmentsAsync();
        Task<List<MilitaryMedicalAssessmentGetDto>> GetAllAssessmentsByPersonelIdAsync(int personelId);
        Task<MilitaryMedicalAssessmentGetDto> GetByIdAssessmentAsync(int id);
    }

}
