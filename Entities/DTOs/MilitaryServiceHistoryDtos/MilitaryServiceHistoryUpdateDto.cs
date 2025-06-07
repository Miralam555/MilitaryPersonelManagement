using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryServiceHistoryDtos
{
    public class MilitaryServiceHistoryUpdateDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public int InjunctionId { get; set; }

        public string OrganizationName { get; set; } = null!;

        public string Position { get; set; } = null!;

        public string OfficialRank { get; set; } = null!;

        public bool IsCurrentMilitary { get; set; }
    }

}
