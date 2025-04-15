using AutoMapper;
using Entities.DTOs.BattleHistoryDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class BattleHistoryMapper:Profile
    {
        public BattleHistoryMapper()
        {
            CreateMap<BattleHistoryAddDto, BattleHistory>();


            CreateMap<BattleHistoryUpdateAndGetDto, BattleHistory>()
                .ForMember(d => d.CreatedDate, opt => opt.Ignore());
                
        }
    }
}
