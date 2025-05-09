using Core.DataAccess;
using Entities.DTOs.FamilyMembersInServiceDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Abstract
{
    public interface IFamilyMemberInServiceDal:IEntityRepository<FamilyMembersInService>
    {
        Task<List<FamilyMembersInServiceGetDto>> GetAllFamilyMembersInServiceAsync();
        Task<List<FamilyMembersInServiceGetDto>> GetAllFamilyMembersInServiceByPersonelIdAsync(int personelId);
        Task<List<FamilyMembersInServiceGetDto>> GetAllFamilyMembersInServiceByMemberIdAsync(int memberId);
        Task<FamilyMembersInServiceGetDto> GetFamilyMemberInServiceByIdAsync(int id);
    }
}
