using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.BattleHistoryDtos
{
    public class BattleHistoryAddDto:IDto
    {
        public int? PersonelId { get; set; }

        public string BattleName { get; set; } = null!;

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string Position { get; set; } = null!;

        public string? InjuryOrDiseaseType { get; set; }

        public string? VeteranNote { get; set; }
    }
}
