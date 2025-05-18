using Core.Entities;

namespace Entities.DTOs.InjunctionDtos
{
    public class InjunctionUpdateDto:IDto
    {

        public int Id { get; set; }

        public string InjunctionNumber { get; set; } = null!;

        public DateOnly InjuctionStartDate { get; set; }

        public bool? InjunctionIsActive { get; set; }

        public int InjunctionTypeId { get; set; }

        public int IssuedByPersonelId { get; set; }
    }

}
