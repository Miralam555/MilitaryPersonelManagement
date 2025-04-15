using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryPersonelDtos
{
    public class MilitaryPersonelGetDto:IDto
    {
        public int Id { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public string Patronymic { get; set; } = null!;

        public DateOnly BirthDate { get; set; }

        public string BirthPlace { get; set; } = null!;
        public MilitaryPersonelInfoGetDto MilitaryPersonelInfoGetDto { get; set; }
        
    }
}
