using Core.Entities;

namespace Entities.DTOs.PersonelForeignLanguageLevel
{
    public class PersonelForeignLanguageLevelUpdateDto:IDto
    {
        public int Id { get; set; }
        public int PersonelId { get; set; }

        public string LanguageName { get; set; } = null!;

        public string LanguageLevel { get; set; } = null!;

        public string? Record { get; set; }

        public int AllowanceInjunctionId { get; set; }
    }

}
