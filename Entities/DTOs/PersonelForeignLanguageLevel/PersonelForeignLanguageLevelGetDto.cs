using Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.DTOs.PersonelForeignLanguageLevel
{
    public class PersonelForeignLanguageLevelGetDto:IDto
    {
        public int Id { get; set; }

        public int PersonelId { get; set; }
        public string PersonelName { get; set; } = null!;

        public string PersonelSurname { get; set; } = null!;

        public string LanguageName { get; set; } = null!;

        public string LanguageLevel { get; set; } = null!;

        public string? Record { get; set; }

        public int AllowanceInjunctionId { get; set; }
        public string InjunctionNumber { get; set; } = null!;
    }
}
