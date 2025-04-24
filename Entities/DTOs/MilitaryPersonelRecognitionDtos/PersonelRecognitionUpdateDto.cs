using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryPersonelRecognitionDtos
{
    public class PersonelRecognitionUpdateDto:IDto
    {
        public int Id { get; set; }

        public int? PersonelId { get; set; }

        public int Injunctionİd { get; set; }

        public string? RecognitionDescription { get; set; }

        public string? Record { get; set; }
    }

}
