using Core.DataAccess;
using Entities.DTOs.MilitaryPersonelRecognitionDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelRecognitionDal : IEntityRepository<MilitaryPersonelRecognition>
    {
        Task<List<PersonelRecognitionGetDto>> GetAllRecognitionsAsync();
        Task<List<PersonelRecognitionGetDto>> GetAllRecognitionsByInjunctionIdAsync(int injunctionId);
        Task<List<PersonelRecognitionGetDto>> GetAllRecognitionsByPersonelIdAsync(int personelId);
        Task<PersonelRecognitionGetDto> GetRecognitionByIdAsync(int id);
    }

}
