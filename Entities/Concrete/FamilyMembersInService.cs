using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public partial class FamilyMembersInService:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public int MemberId { get; set; }

    public string? Record { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  FamilyMember Member { get; set; } = null!;

    public  MilitaryPersonel Personel { get; set; } = null!;
}
