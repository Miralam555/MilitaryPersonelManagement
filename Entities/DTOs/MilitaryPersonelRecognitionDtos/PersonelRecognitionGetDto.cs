using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelRecognitionDtos
{
    public class PersonelRecognitionGetDto:IDto
    {
        public int Id { get; set; }

        public int? PersonelId { get; set; }

        public int Injunctionİd { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;
        public string InjunctionNumber { get; set; } = null!;

        public string? RecognitionDescription { get; set; }

        public string? Record { get; set; }
    }

}
