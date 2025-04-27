using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.MilitaryServiceExtensionDtos
{
    public class MilitaryServiceExtensionUpdateDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }

        public int InjunctionId { get; set; }
        public DateOnly StartDate { get; set; }
        public DateOnly EndDate { get; set; }
        public string? Record { get; set; }
    }

}
