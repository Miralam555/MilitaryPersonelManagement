using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class MilitaryPersonelRecognition:IEntity
{
    public int Id { get; set; }

    public int? PersonelId { get; set; }

    public int InjunctionId { get; set; }

    public string? RecognitionDescription { get; set; }

    public string? Record { get; set; }
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  Injunction InjunctionİdNavigation { get; set; } = null!;

    public  MilitaryPersonel? Personel { get; set; }
}
