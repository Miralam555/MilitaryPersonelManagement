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
            CreateMap<PenaltyAddDto, MilitaryPersonelPenalty>();
            CreateMap<PenaltyUpdateDto, MilitaryPersonelPenalty>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());

        }
    }
}
