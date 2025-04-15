using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MaritalStatus:IEntity
{
    public int Id { get; set; }

    public string? StatusName { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  ICollection<MilitaryPersonelInfo> MilitaryPersonelInfos { get; set; } = new List<MilitaryPersonelInfo>();
}
