using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPersonelInfo:IEntity
{
    public int Id { get; set; }

    public string Nationality { get; set; } = null!;

    public string RegistrationAddress { get; set; } = null!;

    public string CurrentAddress { get; set; } = null!;

    public string IdentityCardNumber { get; set; } = null!;

    public string Pin { get; set; } = null!;

    public string Height { get; set; } = null!;

    public string Weight { get; set; } = null!;

    public string BloodGroup { get; set; } = null!;

    public int MaritalStatusId { get; set; }


    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public MaritalStatus MaritalStatus { get; set; } = null!;

    public  MilitaryPersonel Personel { get; set; } = null!;

}
