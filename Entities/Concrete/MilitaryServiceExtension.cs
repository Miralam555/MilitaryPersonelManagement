using Core.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryServiceExtension:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public int InjunctionId { get; set; }
    public DateOnly StartDate { get; set; } 
    public DateOnly EndDate { get; set; }
    public string? Record { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }
    public Injunction Injunction { get; set; } = null!;

    public  MilitaryPersonel Personel { get; set; } = null!;
}
