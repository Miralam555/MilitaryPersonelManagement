using Core.Entities;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryPersonelDtos
{
    public class MilitaryPersonelAddDto:IDto
    {

        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public string Patronymic { get; set; } = null!;
        
        public DateOnly BirthDate { get; set; } 

        public string BirthPlace { get; set; } = null!;
        public MilitaryPersonelInfoAddDto MilitaryPersonelInfoDto { get; set; } = null!;
    }
}
