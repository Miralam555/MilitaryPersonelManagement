using Core.Utilities.Results;
using Entities.DTOs.FamilyMembersInServiceDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IFamilyMembersInService_Service
    {
        Task<IResult> DeleteFamilyMembersInService(int id);
        Task<IResult> UpdateFamilyMembersInService(FamilyMembersInServiceUpdateAndGetDto dto);
        Task<IResult> AddFamilyMembersInService(FamilyMembersInServiceAddDto dto);
        Task<IDataResult<FamilyMembersInServiceUpdateAndGetDto>> GetByIdFamilyMembersInService(int id);
        Task<IDataResult<List<FamilyMembersInServiceUpdateAndGetDto>>> GetAllFamilyMembersInService();
    }
}
