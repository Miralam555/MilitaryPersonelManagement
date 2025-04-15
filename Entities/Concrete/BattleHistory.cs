using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class BattleHistory:IEntity
{
    public int Id { get; set; }

    public int? PersonelId { get; set; }

    public string BattleName { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public DateOnly EndDate { get; set; }

    public string Position { get; set; } = null!;

    public string? InjuryOrDiseaseType { get; set; }

    public string? VeteranNote { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  MilitaryPersonel? Personel { get; set; }
}
