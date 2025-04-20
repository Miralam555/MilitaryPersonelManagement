using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PersonelForeignLanguageLevel
{
    public class PersonelForeignLanguageLevelAddDto:IDto
    {

        public int PersonelId { get; set; }

        public string LanguageName { get; set; } = null!;

        public string LanguageLevel { get; set; } = null!;

        public string? Record { get; set; }

        public int AllowanceInjunctionId { get; set; }
    }

}
