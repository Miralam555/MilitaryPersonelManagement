using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.InjunctionDtos
{
    public class InjunctionAddDto:IDto
    {
   

        public string InjunctionNumber { get; set; } = null!;

        public DateOnly InjuctionStartDate { get; set; }

        public bool? InjunctionIsActive { get; set; }

        public int InjunctionTypeId { get; set; }

        public int IssuedByPersonelId { get; set; }
    }
}
