using Core.DataAccess;
using Entities.DTOs.PreMilitaryWorkExperienceDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IPreMilitaryWorkExperienceDal : IEntityRepository<PreMilitaryWorkExperience>
    {
        Task<List<PreMilitaryWorkExperienceGetDto>> GetAllExperiencesAsync();
        Task<List<PreMilitaryWorkExperienceGetDto>> GetAllExpereiencesByPersonelId(int personelId);
        Task<PreMilitaryWorkExperienceGetDto> GetExperienceById(int id);
    }

}
