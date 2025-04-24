using FluentValidation;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class PersonelReputationRiskFindingValidator:AbstractValidator<MilitaryPersonelReputationRiskFinding>
    {
        public PersonelReputationRiskFindingValidator()
        {
            
        }
    }
}
