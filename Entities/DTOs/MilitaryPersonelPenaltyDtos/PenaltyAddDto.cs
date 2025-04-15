using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyAddDto : IDto
    {


        public int? PersonelId { get; set; }

        public int PenaltyTypeId { get; set; }
        public int InjunctionId { get; set; }

        public string? PenaltyDescription { get; set; }

        public string? Record { get; set; }


    }

}
