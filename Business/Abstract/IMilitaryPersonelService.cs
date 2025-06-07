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
        Task<IDataResult<List<PersonelGetDto>>> GetAllPersonelsAsync();
        Task<IDataResult<PersonelGetDto>> GetPersonelById(int id);
    }
    

}
