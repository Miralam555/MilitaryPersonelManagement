using AutoMapper;
using Entities.DTOs.FamilyMemberDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class FamilyMemberMapper:Profile
    {
        public FamilyMemberMapper()
        {
            CreateMap<FamilyMemberAddDto, FamilyMember>();
            CreateMap<FamilyMemberUpdateDto, FamilyMember>()
                .ForMember(d=>d.CreatedDate,opt=>opt.Ignore());
           
        }
    }
}
