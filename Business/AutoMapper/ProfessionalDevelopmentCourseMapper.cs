using AutoMapper;
using Entities.DTOs.ProfessionalDevelopmentCourse;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class ProfessionalDevelopmentCourseMapper:Profile
    {
        public ProfessionalDevelopmentCourseMapper()
        {
            CreateMap<ProfessionalDevelopmentCourseAddDto, ProfessionalDevelopmentCourse>();
            CreateMap<ProfessionalDevelopmentCourseUpdateDto, ProfessionalDevelopmentCourse>()
                .ForMember(dest=>dest.CreatedDate,opt=>opt.Ignore());

        }
    }
}
