using AutoMapper;
using Entities.DTOs.PreMilitaryWorkExperienceDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class PreMilitaryWorkExperienceMapper:Profile
    {
        public PreMilitaryWorkExperienceMapper()
        {
            CreateMap<PreMilitaryWorkExperienceAddDto, PreMilitaryWorkExperience>();
            CreateMap<PreMilitaryWorkExperienceUpdateDto, PreMilitaryWorkExperience>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
