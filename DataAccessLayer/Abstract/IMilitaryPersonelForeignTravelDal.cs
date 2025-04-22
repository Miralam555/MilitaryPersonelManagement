using Core.DataAccess;
using Entities.DTOs.PersonelForeignTravelDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelForeignTravelDal : IEntityRepository<MilitaryPersonelForeignTravel>
    {
        Task<PersonelForeignTravelGetDto> GetByIdAsync(int id);
        Task<List<PersonelForeignTravelGetDto>> GetAllByPersonelIdAsync(int personelId);
        Task<List<PersonelForeignTravelGetDto>> GetAllByInjunctionIdAsync(int injunctionId);
        Task<List<PersonelForeignTravelGetDto>> GetAllTravelsAsync();
    }

}
