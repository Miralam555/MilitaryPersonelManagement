using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPenaltyType:IEntity
{
    public int Id { get; set; }

    public string PenaltyType { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  ICollection<MilitaryPersonelPenalty> MilitaryPersonelPenalties { get; set; } = new List<MilitaryPersonelPenalty>();
}
