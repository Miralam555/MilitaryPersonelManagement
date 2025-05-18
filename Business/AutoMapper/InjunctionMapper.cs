using AutoMapper;
using Entities.DTOs.InjunctionDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class InjunctionMapper:Profile
    {
        public InjunctionMapper()
        {
            CreateMap<InjunctionAddDto, Injunction>();

            CreateMap<InjunctionUpdateDto, Injunction>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
        }
    }
}
