using Core.Entities;

namespace Entities.DTOs.InjunctionDtos
{
    public class InjunctionGetDto:IDto
    {

        public int Id { get; set; }

        public string InjunctionNumber { get; set; } = null!;

        public DateOnly InjuctionStartDate { get; set; }

        public bool? InjunctionIsActive { get; set; }

        public int InjunctionTypeId { get; set; }
        public string InjunctionName { get; set; } = null!;

        public int IssuedByPersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;
    }

}
