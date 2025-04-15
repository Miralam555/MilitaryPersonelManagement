using Core.Entities;

using System;
using System.Collections.Generic;

namespace MyMilitaryFinalProject.Entities.Concrete;

public  class ServiceYearsWithBenefit:IEntity
{
    public int Id { get; set; }

    public int PersonelId { get; set; }

    public DateOnly AppoinmentOrderDate { get; set; }

    public DateOnly ReleaseOrderDate { get; set; }

    public string OrganizationName { get; set; } = null!;

    public string BenefitDocumentName { get; set; } = null!;

    public DateOnly BenefitDocumentDate { get; set; }

    public string BenefitDocumentNumber { get; set; } = null!;
    public DateTime CreatedDate { get; set; }
    public DateTime? UpdatedDate { get; set; }

    public  MilitaryPersonel Personel { get; set; } = null!;
}
