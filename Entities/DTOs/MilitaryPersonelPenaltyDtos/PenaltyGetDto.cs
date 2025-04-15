using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryPersonelPenaltyDtos
{
    public class PenaltyGetDto:IDto
    {
        public int Id { get; set; }

        public int? PersonelId { get; set; }

        public int PenaltyTypeId { get; set; }
        public int InjunctionId { get; set; }

        public string? PenaltyDescription { get; set; }

        public string? Record { get; set; }
        public PenaltyTypeGetDto PenaltyTypeGetDto { get; set; }
        public PenaltyPersonelGetDto PenaltyPersonelGetDto { get; set; }
        public PenaltyInjunctionGetDto PenaltyInjunctionGetDto { get; set; }

    }
}
