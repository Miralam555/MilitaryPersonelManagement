using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryMedicalAssessment:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public DateOnly AssesmentDate { get; set; }

    public string Diagnosis { get; set; } = null!;

    public string Opinion { get; set; } = null!;

    public string? Record { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  MilitaryPersonel Personel { get; set; } = null!;
}
