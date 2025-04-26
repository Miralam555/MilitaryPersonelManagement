using Core.Entities;

namespace Entities.DTOs.MilitaryRankDtos
{
    public class MilitaryRankAddDto:IDto
    {

        public int PersonelId { get; set; }

        public int InjunctionId { get; set; }

        public string RankName { get; set; } = null!;
    }

}
