using AutoMapper;
using Entities.DTOs.MilitaryPersonelDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryPersonelMapper : Profile
    {
        public MilitaryPersonelMapper()
        {
            CreateMap<MilitaryPersonelAddDto, MilitaryPersonel>()
               .ForMember(dest => dest.MilitaryPersonelInfo, opt => opt.MapFrom(src => src.MilitaryPersonelInfoDto));

            CreateMap<MilitaryPersonelInfoAddDto, MilitaryPersonelInfo>();


            CreateMap<MilitaryPersonelUpdateDto, MilitaryPersonel>()
              .ForMember(dest => dest.MilitaryPersonelInfo, opt => opt.MapFrom(src => src.MilitaryPersonelInfoUpdateDto));

            CreateMap<MilitaryPersonelInfoUpdateDto, MilitaryPersonelInfo>();


            CreateMap<MilitaryPersonel, MilitaryPersonelGetDto>()
                .ForMember(dest=>dest.MilitaryPersonelInfoGetDto,opt=>opt.MapFrom(src=>src.MilitaryPersonelInfo));
            CreateMap<MilitaryPersonelInfo, MilitaryPersonelInfoGetDto>()
                .ForMember(dest=>dest.MaritalStatusGetDto,opt=>opt.MapFrom(src=>src.MaritalStatus));
            CreateMap<MaritalStatus, MaritalStatusGetDto>();

               

        }
    }
}
