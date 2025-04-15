using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class FamilyMember:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public string RelationShip { get; set; } = null!;

    public string MemberName { get; set; } = null!;

    public string MemberSurName { get; set; } = null!;

    public string MemberPatronymic { get; set; } = null!;

    public DateOnly BirthDate { get; set; }

    public string BirthPlace { get; set; } = null!;

    public string Occupation { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  ICollection<CrimeRecord> CrimeRecords { get; set; } = new List<CrimeRecord>();

    public  ICollection<FamilyMembersInService> FamilyMembersInServices { get; set; } = new List<FamilyMembersInService>();

    public  ICollection<MilitaryPersonelFamilyMemberForeignTravel> MilitaryPersonelFamilyMemberForeignTravels { get; set; } = new List<MilitaryPersonelFamilyMemberForeignTravel>();

    public  MilitaryPersonel Personel { get; set; } = null!;
}
