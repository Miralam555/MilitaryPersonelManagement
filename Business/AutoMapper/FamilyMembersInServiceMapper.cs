using AutoMapper;
using Entities.DTOs.FamilyMembersInServiceDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class FamilyMembersInServiceMapper:Profile
    {
        public FamilyMembersInServiceMapper()
        {
            CreateMap<FamilyMembersInServiceAddDto, FamilyMembersInService>();
            CreateMap<FamilyMembersInServiceUpdateDto, FamilyMembersInService>()
                .ForMember(d => d.CreatedDate, opt => opt.Ignore());
        }
    }
}
