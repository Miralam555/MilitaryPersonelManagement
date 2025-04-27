using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitarySkillRecordDtos
{
    public class MilitarySkillRecordUpdateDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string SkillDegree { get; set; } = null!;

        public int IssuedByInjunctionId { get; set; }

        public int ApprovedByInjunctionId { get; set; }

        public string? Record { get; set; }
    }

}
