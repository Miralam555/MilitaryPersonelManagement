using AutoMapper;
using Entities.DTOs.EducationDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryPersonelEducationMapper:Profile
    {
        public MilitaryPersonelEducationMapper()
        {
            CreateMap<EducationAddDto, MilitaryPersonelEducation>();
            CreateMap<EducationUpdateDto, MilitaryPersonelEducation>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
