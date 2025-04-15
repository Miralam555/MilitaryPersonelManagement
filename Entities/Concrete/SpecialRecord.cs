using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class SpecialRecord:IEntity
{
    public int Id { get; set; }

    public int MilitaryPersonelId { get; set; }

    public string InformationDetails { get; set; } = null!;

    public string ReportedBy { get; set; } = null!;

    public string? Record { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  MilitaryPersonel MilitaryPersonel { get; set; } = null!;
}
