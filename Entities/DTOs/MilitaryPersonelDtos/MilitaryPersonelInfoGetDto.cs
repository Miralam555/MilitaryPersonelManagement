using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryPersonelDtos
{
    public class MilitaryPersonelInfoGetDto
    {
        public string Nationality { get; set; } = null!;

        public string RegistrationAddress { get; set; } = null!;

        public string CurrentAddress { get; set; } = null!;

        public string IdentityCardNumber { get; set; } = null!;

        public string Pin { get; set; } = null!;

        public string Height { get; set; } = null!;

        public string Weight { get; set; } = null!;

        public string BloodGroup { get; set; } = null!;
        public MaritalStatusGetDto MaritalStatusGetDto { get; set; }
    }
}
