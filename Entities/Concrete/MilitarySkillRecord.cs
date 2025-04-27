using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitarySkillRecord:IEntity
{
    public int Id { get; set; }
    public int PersonelId { get; set; }
    public string SkillDegree { get; set; } = null!;

    public int IssuedByInjunctionId { get; set; }

    public int ApprovedByInjunctionId { get; set; }

    public string? Record { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public Injunction Injunction { get; set; } = null!;
    public  MilitaryPersonel Personel { get; set; } = null!;
}
