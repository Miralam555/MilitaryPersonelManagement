using AutoMapper;
using Entities.DTOs.MilitaryServiceHistoryDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryServiceHistoryMapper:Profile
    {
        public MilitaryServiceHistoryMapper()
        {
            CreateMap<MilitaryServiceHistoryAddDto, MilitaryServiceHistory>();
            CreateMap<MilitaryServiceHistoryUpdateDto, MilitaryServiceHistory>()
                .ForMember(dest=>dest.CreatedDate ,opt=>opt.Ignore());
        }
    }
}
