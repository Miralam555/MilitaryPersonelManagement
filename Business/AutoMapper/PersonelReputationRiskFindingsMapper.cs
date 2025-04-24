using AutoMapper;
using Entities.DTOs.PersonelReputationRiskFindingDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class PersonelReputationRiskFindingsMapper:Profile
    {
        public PersonelReputationRiskFindingsMapper()
        {
            CreateMap<PersonelReputationRiskFindingAddDto, MilitaryPersonelReputationRiskFinding>();
            CreateMap<PersonelReputationRiskFindingUpdateDto, MilitaryPersonelReputationRiskFinding>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
        }
    }
}
