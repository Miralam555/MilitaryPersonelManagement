using Core.DataAccess;
using Entities.DTOs.InjunctionDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IInjunctionDal : IEntityRepository<Injunction>
    {
        Task<List<InjunctionGetDto>> GetAllInjunctionWithDetailsAsync();
        Task<List<InjunctionGetDto>> GetAllInjunctionsByPersonelIdAsync(int personelId);
        Task<InjunctionGetDto> GetInjunctionByIdAsync(int id);
    }

}
