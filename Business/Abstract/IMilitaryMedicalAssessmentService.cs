using Core.Utilities.Results;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface IMilitaryMedicalAssessmentService
    {
        Task<IDataResult<List<MilitaryMedicalAssessmentGetDto>>> GetAllAssessmentsAsync();
        Task<IDataResult<List<MilitaryMedicalAssessmentGetDto>>> GetAllAssessmentsByPersonelIdAsync(int personelId);
        Task<IDataResult<MilitaryMedicalAssessmentGetDto>> GetAssessmentByIdAsync(int id);
        Task<IResult> AddAssessmentAsync(MilitaryMedicalAssessmentAddDto dto);
        Task<IResult> UpdateAssesmentAsync(MilitaryMedicalAssessmentUpdateDto dto);
        Task<IResult> DeleteAssesmentAsync(int id);
    }


}
