using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class Injunction:IEntity
{
    public int Id { get; set; }

    public string InjunctionNumber { get; set; } = null!;

    public DateOnly InjuctionStartDate { get; set; }

    public bool? InjunctionIsActive { get; set; }

    public int InjunctionTypeId { get; set; }

    public int IssuedByPersonelId { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  InjunctionType InjunctionType { get; set; } = null!;
    public MilitaryRank MilitaryRank { get; set; } = null!;
    public  MilitaryPersonel IssuedByPersonel { get; set; } = null!;
    public MilitarySkillRecord MilitarySkillRecord { get; set; }=null!;
    public MilitaryServiceHistory MilitaryServiceHistory { get; set; } = null!;
    public ICollection<MilitaryServiceExtension> MilitaryServiceExtensions { get; set; } = new List<MilitaryServiceExtension>();

    public  ICollection<MilitaryPersonelForeignLanguageLevel> MilitaryPersonelForeignLanguageLevels { get; set; } = new List<MilitaryPersonelForeignLanguageLevel>();

    public  ICollection<MilitaryPersonelForeignTravel> MilitaryPersonelForeignTravels { get; set; } = new List<MilitaryPersonelForeignTravel>();

    public  ICollection<MilitaryPersonelPenalty> MilitaryPersonelPenalties { get; set; } = new List<MilitaryPersonelPenalty>();

    public  ICollection<MilitaryPersonelRecognition> MilitaryPersonelRecognitions { get; set; } = new List<MilitaryPersonelRecognition>();

    

    public  ICollection<ProfessionalDevelopmentCourse> ProfessionalDevelopmentCourses { get; set; } = new List<ProfessionalDevelopmentCourse>();
}
