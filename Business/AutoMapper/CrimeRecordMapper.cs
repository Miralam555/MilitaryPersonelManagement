using AutoMapper;
using Entities.DTOs.CrimeRecordDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class CrimeRecordMapper:Profile
    {
        public CrimeRecordMapper()
        {
            CreateMap<CrimeRecordAddDto, CrimeRecord>();

            CreateMap<CrimeRecordUpdateAndGetDto, CrimeRecord>()
                .ForMember(dest => dest.CreatedDate, opt => opt.Ignore());
            CreateMap<CrimeRecord, CrimeRecordUpdateAndGetDto>();
        }
    }
}
