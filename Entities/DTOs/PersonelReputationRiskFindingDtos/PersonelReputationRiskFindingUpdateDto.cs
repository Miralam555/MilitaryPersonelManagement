using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PersonelReputationRiskFindingDtos
{
    public class PersonelReputationRiskFindingUpdateDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public string Info { get; set; } = null!;

        public string ReportingAgency { get; set; } = null!;

        public string? Record { get; set; }
    }

}
