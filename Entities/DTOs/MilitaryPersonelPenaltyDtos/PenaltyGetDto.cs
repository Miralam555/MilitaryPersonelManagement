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
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public int PenaltyTypeId { get; set; }
        public string PenaltyType { get; set; } = null!;

        public string? PenaltyDescription { get; set; }

        public string? Record { get; set; }

        public int InjunctionId { get; set; }
        public string InjunctionNumber { get; set; } = null!;

    }

}
