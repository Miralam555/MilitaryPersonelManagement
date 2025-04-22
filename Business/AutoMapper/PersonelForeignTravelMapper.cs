using AutoMapper;
using Entities.DTOs.PersonelForeignTravelDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class PersonelForeignTravelMapper:Profile
    {
        public PersonelForeignTravelMapper()
        {
            CreateMap<PersonelForeignTravelAddDto, MilitaryPersonelForeignTravel>();
            CreateMap<PersonelForeignTravelUpdateDto, MilitaryPersonelForeignTravel>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
