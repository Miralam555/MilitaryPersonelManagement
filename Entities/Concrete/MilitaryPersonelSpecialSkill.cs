using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPersonelSpecialSkill:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public string? Skill { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public  MilitaryPersonel Personel { get; set; } = null!;
}
