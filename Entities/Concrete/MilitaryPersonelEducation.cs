using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPersonelEducation:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public string InstitutionName { get; set; } = null!;

    public DateOnly GraduationYear { get; set; }

    public string Specialization { get; set; } = null!;

    public string Degree { get; set; } = null!;

    public int EducationTypeId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  EducationType EducationType { get; set; } = null!;

    public  MilitaryPersonel Personel { get; set; } = null!;
}
