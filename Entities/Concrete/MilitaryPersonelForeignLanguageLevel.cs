using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public class MilitaryPersonelForeignLanguageLevel:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public string LanguageName { get; set; } = null!;

    public string LanguageLevel { get; set; } = null!;

    public string? Record { get; set; }

    public int AllowanceInjunctionId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  Injunction AllowanceInjunction { get; set; } = null!;

    public  MilitaryPersonel Personel { get; set; } = null!;
}
