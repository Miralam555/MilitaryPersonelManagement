using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class ProfessionalDevelopmentCourse:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public int InjunctionId { get; set; }

    public string OrganizedLocation { get; set; } = null!;

    public string CourseName { get; set; } = null!;

    public string Specialization { get; set; } = null!;

    public DateOnly StartDate { get; set; }

    public string Duration { get; set; } = null!;

    public bool IsCurrentMilitary { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  Injunction Injunction { get; set; } = null!;

    public  MilitaryPersonel Personel { get; set; } = null!;
}
