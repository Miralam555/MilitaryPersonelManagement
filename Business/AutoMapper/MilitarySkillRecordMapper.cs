using AutoMapper;
using Entities.DTOs.MilitarySkillRecordDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitarySkillRecordMapper:Profile
    {
        public MilitarySkillRecordMapper()
        {
            CreateMap<MilitarySkillRecordAddDto, MilitarySkillRecord>();
            CreateMap<MilitarySkillRecordUpdateDto, MilitarySkillRecord>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
