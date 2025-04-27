using AutoMapper;
using Entities.DTOs.MilitaryServiceExtensionDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryServiceExtensionMapper:Profile
    {
        public MilitaryServiceExtensionMapper()
        {
            CreateMap<MilitaryServiceExtensionAddDto, MilitaryServiceExtension>();
            CreateMap<MilitaryServiceExtensionUpdateDto, MilitaryServiceExtension>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
