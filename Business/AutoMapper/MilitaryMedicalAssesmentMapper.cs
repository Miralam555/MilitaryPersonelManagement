using AutoMapper;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class MilitaryMedicalAssesmentMapper:Profile
    {
        public MilitaryMedicalAssesmentMapper()
        {
            CreateMap<MilitaryMedicalAssessmentAddDto, MilitaryMedicalAssessment>();

            CreateMap<MilitaryMedicalAssessmentUpdateDto, MilitaryMedicalAssessment>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());
                
        }
    }
}
