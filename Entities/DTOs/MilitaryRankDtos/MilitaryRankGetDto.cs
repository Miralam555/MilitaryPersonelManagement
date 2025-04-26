using Core.Entities;

namespace Entities.DTOs.MilitaryRankDtos
{
    public class MilitaryRankGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public int InjunctionId { get; set; }
        public string InjunctionNumber { get; set; } = null!;

        public string RankName { get; set; } = null!;
    }

}
