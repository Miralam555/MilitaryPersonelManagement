using AutoMapper;
using Entities.DTOs.MilitaryPersonelRecognitionDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.AutoMapper
{
    public class PersonelRecognitionMapper:Profile
    {
        public PersonelRecognitionMapper()
        {
            CreateMap<PersonelRecognitionAddDto, MilitaryPersonelRecognition>();
            CreateMap<PersonelRecognitionUpdateDto, MilitaryPersonelRecognition>()
                .ForMember(dest=>dest.CreatedDate ,opt=>opt.Ignore());
        }
    }
}
