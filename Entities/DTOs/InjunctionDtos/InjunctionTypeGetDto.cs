using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.InjunctionDtos
{
    public class InjunctionTypeGetDto:IDto
    {
        public int Id { get; set; }
        public string InjunctionName { get; set; } = null!;
    }
}
