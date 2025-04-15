using Entities.DTOs.MilitaryPersonelDtos;
using FluentValidation;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class MilitaryPersonelValidator:AbstractValidator<MilitaryPersonelAddDto>
    {
        public MilitaryPersonelValidator()
        {
            RuleFor(p => p.MilitaryPersonelInfoDto.IdentityCardNumber).Must(IdentityCardNumberStartsWithAAorAZE);
            RuleFor(p => p.MilitaryPersonelInfoDto.BloodGroup).Must(BloodGroupMatchMyRegex);
        }
        private bool IdentityCardNumberStartsWithAAorAZE(string argument)
        {
            if (argument.StartsWith("AA") || argument.StartsWith("AZE"))
            {
                return true;
            }
            return false;
        }
        private bool BloodGroupMatchMyRegex(string argument)
        {
            Regex regex = new Regex(@"^[1-4]RH\([+-]\)$");
            if (regex.IsMatch(argument))
                return true;
            return false;
        }
    }
}
