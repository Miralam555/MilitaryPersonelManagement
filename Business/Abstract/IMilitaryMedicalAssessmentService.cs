using Core.Utilities.Results;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface IMilitaryMedicalAssessmentService
    {
        Task<IResult> DeleteAsync(int id);
        Task<IResult> UpdateAsync(MilitaryMedicalAsssessmentGetDto dto);
        Task<IResult> AddAsync(MilitaryMedicalAssessmentAddDto dto);
        Task<IDataResult<MilitaryMedicalAssessment>> GetByIdAsync(int id);

        Task<IDataResult<List<MilitaryMedicalAsssessmentGetDto>>> GetAllByPersonelIdAsync(int id);
       
        Task<IDataResult<List<MilitaryMedicalAsssessmentGetDto>>> GetAllAsync();
    }


}
