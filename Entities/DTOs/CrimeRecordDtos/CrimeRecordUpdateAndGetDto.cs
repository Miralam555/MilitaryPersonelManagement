using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.CrimeRecordDtos
{
    public class CrimeRecordUpdateAndGetDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }

        public int? MemberId { get; set; }

        public string ChargeDescription { get; set; } = null!;

        public string ChargeDuration { get; set; } = null!;

        public string PenalInstitution { get; set; } = null!;

        public string? Record { get; set; }
    }
}
