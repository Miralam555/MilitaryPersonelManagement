using Core.Entities;

using System;
using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPersonel:IEntity
{
    public int Id { get; set; }

    public string PersonelName { get; set; } = null!;

    public string PersonelSurname { get; set; } = null!;

    public string Patronymic { get; set; } = null!;
    
    public DateOnly BirthDate { get; set; }

    public string BirthPlace { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  ICollection<BattleHistory> BattleHistories { get; set; } = new List<BattleHistory>();

    public  ICollection<CrimeRecord> CrimeRecords { get; set; } = new List<CrimeRecord>();

    public  ICollection<FamilyMember> FamilyMembers { get; set; } = new List<FamilyMember>();

    public  ICollection<FamilyMembersInService> FamilyMembersInServices { get; set; } = new List<FamilyMembersInService>();

    public  ICollection<Injunction> Injunctions { get; set; } = new List<Injunction>();

    public  ICollection<MilitaryMedicalAssessment> MilitaryMedicalAssessments { get; set; } = new List<MilitaryMedicalAssessment>();

    public  ICollection<MilitaryPersonelEducation> MilitaryPersonelEducations { get; set; } = new List<MilitaryPersonelEducation>();

    public  ICollection<MilitaryPersonelForeignLanguageLevel> MilitaryPersonelForeignLanguageLevels { get; set; } = new List<MilitaryPersonelForeignLanguageLevel>();

    public  ICollection<MilitaryPersonelForeignTravel> MilitaryPersonelForeignTravels { get; set; } = new List<MilitaryPersonelForeignTravel>();

    public MilitaryPersonelInfo MilitaryPersonelInfo { get; set; } = null!;

    public  ICollection<MilitaryPersonelPenalty> MilitaryPersonelPenalties { get; set; } = new List<MilitaryPersonelPenalty>();

    public  ICollection<MilitaryPersonelRecognition> MilitaryPersonelRecognitions { get; set; } = new List<MilitaryPersonelRecognition>();

    public  ICollection<MilitaryPersonelReputationRiskFinding> MilitaryPersonelReputationRiskFindings { get; set; } = new List<MilitaryPersonelReputationRiskFinding>();

    public  ICollection<MilitaryPersonelSpecialSkill> MilitaryPersonelSpecialSkills { get; set; } = new List<MilitaryPersonelSpecialSkill>();

    public  ICollection<MilitaryRank> MilitaryRanks { get; set; } = new List<MilitaryRank>();

    public  ICollection<MilitaryServiceExtension> MilitaryServiceExtensions { get; set; } = new List<MilitaryServiceExtension>();

    public MilitaryServiceHistory MilitaryServiceHistory { get; set; } = null!;

    public MilitarySkillRecord MilitarySkillRecord { get; set; } = null!;

    public  ICollection<PreMilitaryWorkExperience> PreMilitaryWorkExperiences { get; set; } = new List<PreMilitaryWorkExperience>();

    public  ICollection<ProfessionalDevelopmentCourse> ProfessionalDevelopmentCourses { get; set; } = new List<ProfessionalDevelopmentCourse>();

    public  ICollection<ServiceYearsWithBenefit> ServiceYearsWithBenefits { get; set; } = new List<ServiceYearsWithBenefit>();

    public  ICollection<SpecialRecord> SpecialRecords { get; set; } = new List<SpecialRecord>();
}
