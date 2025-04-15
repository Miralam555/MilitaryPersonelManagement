using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryRank:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public int InjunctionId { get; set; }

    public string RankName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  Injunction Injunction { get; set; } = null!;

    public  MilitaryPersonel Personel { get; set; } = null!;
}
