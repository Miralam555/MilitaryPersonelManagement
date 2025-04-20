using Core.DataAccess;
using Entities.DTOs.EducationDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelEducationDal : IEntityRepository<MilitaryPersonelEducation>
    {
        Task<List<EducationGetDto>> GetAllEducationsAsync();
        Task<List<EducationGetDto>> GetAllEducationByPersonelIdAsync(int personelId);
        Task<EducationGetDto> GetEducationByIdAsync(int id);
    }

}
