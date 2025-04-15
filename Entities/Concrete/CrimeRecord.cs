using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class CrimeRecord: IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public int? MemberId { get; set; }

    public string ChargeDescription { get; set; } = null!;

    public string ChargeDuration { get; set; } = null!;

    public string PenalInstitution { get; set; } = null!;

    public string? Record { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public FamilyMember? Member { get; set; }

    public  MilitaryPersonel Personel { get; set; } = null!;
}
