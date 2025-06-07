using Core.DataAccess;
using Entities.DTOs.MilitaryPersonelDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IMilitaryPersonelDal:IEntityRepository<MilitaryPersonel>
    {
        Task<List<PersonelGetDto>> GetAllPersonelDetails();
        Task<PersonelGetDto> GetByIdPersonelDetails(int id);
    }

}
