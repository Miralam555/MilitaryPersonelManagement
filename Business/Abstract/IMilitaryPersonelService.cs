using Core.Utilities.Results;
using Entities.DTOs.MilitaryPersonelDtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IMilitaryPersonelService
    {
        Task<IResult> PersonelAddAsync(MilitaryPersonelAddDto dto);
        Task<IResult> PersonelUpdateAsync(MilitaryPersonelUpdateDto dto);
        Task<IDataResult<List<MilitaryPersonelGetDto>>> GetAllPersonelAsync();
        Task<IDataResult<MilitaryPersonelGetDto>> GetByIdPersonel(int id);
    }
    

}
