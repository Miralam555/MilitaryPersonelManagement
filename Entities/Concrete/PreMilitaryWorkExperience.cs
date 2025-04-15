using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class PreMilitaryWorkExperience:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public DateOnly WorkStartDate { get; set; }

    public DateOnly WorkEndDate { get; set; }

    public string CompanyName { get; set; } = null!;

    public string Position { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  MilitaryPersonel Personel { get; set; } = null!;
}
