
using Core.Entities;
using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPersonelPenalty:IEntity
{
    public int Id { get; set; }

    public int? PersonelId { get; set; }

    public int PenaltyTypeId { get; set; }

    public string? PenaltyDescription { get; set; }

    public string? Record { get; set; }

    public int InjunctionId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  Injunction Injunction { get; set; } = null!;

    public  MilitaryPenaltyType PenaltyType { get; set; } = null!;

    public  MilitaryPersonel? Personel { get; set; }
}
