using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class EducationType:IEntity
{
    public int Id { get; set; }

    public string EducationTypeName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  ICollection<MilitaryPersonelEducation> MilitaryPersonelEducations { get; set; } = new List<MilitaryPersonelEducation>();
}
