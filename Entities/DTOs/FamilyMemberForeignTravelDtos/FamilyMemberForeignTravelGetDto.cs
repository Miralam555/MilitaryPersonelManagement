using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.FamilyMemberForeignTravelDtos
{
    public class FamilyMemberForeignTravelGetDto:IDto
    {
        public int Id { get; set; }

        public int MemberId { get; set; }
        public string MemberName { get; set; } = null!;

        public string MemberSurName { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string TravellingCountryName { get; set; } = null!;

        public string? TravelReason { get; set; }

        public string? Record { get; set; }

    }
}
