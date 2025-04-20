using AutoMapper;
using Entities.DTOs.FamilyMemberForeignTravelDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class FamilyMemberForeignTravelMapper:Profile
    {
        public FamilyMemberForeignTravelMapper()
        {
            CreateMap<FamilyMemberForeignTravelAddDto,MilitaryPersonelFamilyMemberForeignTravel >();
            CreateMap<FamilyMemberForeignTraveUpdateDto, MilitaryPersonelFamilyMemberForeignTravel>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
