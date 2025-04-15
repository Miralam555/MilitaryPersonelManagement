using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryServiceHistory:IEntity
{
    public int Id { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public int InjunctionId { get; set; }

    public string OrganizationName { get; set; } = null!;

    public string Position { get; set; } = null!;

    public string OfficialRank { get; set; } = null!;

    public bool IsCurrentMilitary { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public Injunction Injunction { get; set; } = null!;
    public  MilitaryPersonel Personel { get; set; } = null!;
}
