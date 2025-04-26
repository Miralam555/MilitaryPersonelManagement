using AutoMapper;
using Entities.DTOs.PersonelSpecialSkillDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class PersonelSpecialSkillMapper:Profile
    {
        public PersonelSpecialSkillMapper()
        {
            CreateMap<PersonelSpecialSkillAddDto, MilitaryPersonelSpecialSkill>();
            CreateMap<PersonelSpecialSkillUpdateDto, MilitaryPersonelSpecialSkill>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
