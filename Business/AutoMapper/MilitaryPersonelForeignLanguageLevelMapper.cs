using AutoMapper;
using Entities.DTOs.PersonelForeignLanguageLevel;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryPersonelForeignLanguageLevelMapper:Profile
    {
        public MilitaryPersonelForeignLanguageLevelMapper()
        {
            CreateMap<PersonelForeignLanguageLevelAddDto, MilitaryPersonelForeignLanguageLevel>();
            CreateMap<PersonelForeignLanguageLevelUpdateDto, MilitaryPersonelForeignLanguageLevel>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
