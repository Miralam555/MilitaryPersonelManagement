using Core.Utilities.Results;
using Entities.DTOs.MilitaryPersonelDtos;
using MyMilitaryFinalProject.Entities.Concrete;

namespace Business.Abstract
{
    public interface IMilitaryPersonelService
    {
        Task<IResult> PersonelAddAsync(MilitaryPersonelAddDto dto);
        Task<IResult> PersonelUpdateAsync(MilitaryPersonelUpdateDto dto);
        Task<IDataResult<List<MilitaryPersonel>>> GetAllPersonelsAsync();
        Task<IDataResult<MilitaryPersonel>> GetPersonelById(int id);
    }
    

}
