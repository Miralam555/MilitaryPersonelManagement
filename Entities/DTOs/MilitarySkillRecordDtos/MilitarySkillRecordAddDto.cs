using Core.Entities;

namespace Entities.DTOs.MilitarySkillRecordDtos
{
    public class MilitarySkillRecordAddDto:IDto
    {
        public int PersonelId { get; set; }
        public string SkillDegree { get; set; } = null!;

        public int IssuedByInjunctionId { get; set; }

        public int ApprovedByInjunctionId { get; set; }

        public string? Record { get; set; }
    }

}
