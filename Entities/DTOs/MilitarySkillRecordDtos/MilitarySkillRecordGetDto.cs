using Core.Entities;

namespace Entities.DTOs.MilitarySkillRecordDtos
{
    public class MilitarySkillRecordGetDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }
        public string SkillDegree { get; set; } = null!;

        public int IssuedByInjunctionId { get; set; }
        public string InjunctionNumber { get; set; } = null!;

        public int ApprovedByInjunctionId { get; set; }
        public string ApprovedInjunctionNumber { get; set; } = null!;

        public string? Record { get; set; }
    }

}
