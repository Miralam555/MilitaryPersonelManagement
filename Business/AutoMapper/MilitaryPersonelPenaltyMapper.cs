using AutoMapper;
using Entities.DTOs.MilitaryPersonelPenaltyDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryPersonelPenaltyMapper:Profile
    {
        public MilitaryPersonelPenaltyMapper()
        {
            CreateMap<InjunctionType, PenaltyInjunctionTypeGetDto>();
            CreateMap<MilitaryPenaltyType, PenaltyTypeGetDto>();
            CreateMap<Injunction, PenaltyInjunctionGetDto>()
                .ForMember(dest=>dest.PenaltyInjunctionTypeGetDto,opt=>opt.MapFrom(src=>src.InjunctionType));
            CreateMap<MilitaryPersonel, PenaltyPersonelGetDto>();
            CreateMap<MilitaryPersonelPenalty, PenaltyGetDto>()
                .ForMember(dest=>dest.PenaltyInjunctionGetDto,opt=>opt.MapFrom(src=>src.Injunction))
                .ForMember(dest=>dest.PenaltyPersonelGetDto,opt=>opt.MapFrom(src=>src.Personel))
                .ForMember(dest=>dest.PenaltyTypeGetDto,opt=>opt.MapFrom(src=>src.PenaltyType));





            CreateMap<PenaltyAddDto, MilitaryPersonelPenalty>();


            CreateMap<PenaltyUpdateDto, MilitaryPersonelPenalty>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());



        }
    }
}
