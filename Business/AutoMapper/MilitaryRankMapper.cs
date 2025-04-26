using AutoMapper;
using Entities.DTOs.MilitaryRankDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryRankMapper:Profile
    {
        public MilitaryRankMapper()
        {
            CreateMap<MilitaryRankAddDto, MilitaryRank>();
            CreateMap<MilitaryRankUpdateDto, MilitaryRank>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
