using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class InjunctionType:IEntity
{
    public int Id { get; set; }

    public string InjunctionName { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  ICollection<Injunction> Injunctions { get; set; } = new List<Injunction>();
}
