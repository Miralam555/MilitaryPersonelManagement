using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PersonelForeignTravelDtos
{
    public class PersonelForeignTravelAddDto:IDto
    {
        public int PersonelId { get; set; }

        public DateOnly StartDate { get; set; }

        public DateOnly EndDate { get; set; }

        public string TravellingCountryName { get; set; } = null!;

        public string? TravelReason { get; set; }

        public string? Record { get; set; }

        public int InjunctionId { get; set; }
    }

}
