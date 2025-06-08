using Core.Entities;

namespace Entities.DTOs.MilitaryPersonelRecognitionDtos
{
    public class PersonelRecognitionAddDto:IDto
    {
      

        public int? PersonelId { get; set; }

        public int InjunctionId { get; set; }

        public string? RecognitionDescription { get; set; }

        public string? Record { get; set; }
    }

}
