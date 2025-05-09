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
        Task<IResult> UpdateFamilyMembersInService(FamilyMembersInServiceUpdateDto dto);
        Task<IResult> AddFamilyMembersInService(FamilyMembersInServiceAddDto dto);
        Task<IDataResult<List<FamilyMembersInServiceGetDto>>> GetAllFamilyMembersInService();
        Task<IDataResult<List<FamilyMembersInServiceGetDto>>> GetAllFamilyMembersInServiceByPersonelId(int personelId);
        Task<IDataResult<FamilyMembersInServiceGetDto>> GetByIdFamilyMemberInService(int id);
        Task<IDataResult<List<FamilyMembersInServiceGetDto>>> GetAllFamilyMembersInServiceByMemberId(int memberId);
    }
}
