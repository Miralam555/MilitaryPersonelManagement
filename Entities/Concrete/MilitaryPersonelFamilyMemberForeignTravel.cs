using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPersonelFamilyMemberForeignTravel :IEntity
{
    public int Id { get; set; }

    public int MemberId { get; set; }

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string TravellingCountryName { get; set; } = null!;

    public string? TravelReason { get; set; }

    public string? Record { get; set; }

    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public  FamilyMember Member { get; set; } = null!;
}
