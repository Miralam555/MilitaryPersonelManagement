using FluentValidation;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class FamilyMemberValidator:AbstractValidator<FamilyMember>
    {
        public FamilyMemberValidator()
        {
            RuleFor(e => e.RelationShip).MinimumLength(3).MaximumLength(30).NotEmpty().NotNull();
            RuleFor(e => e.MemberName).MinimumLength(3).MaximumLength(20).NotEmpty().NotNull();
            RuleFor(e => e.MemberSurName).MinimumLength(3).MaximumLength(20).NotEmpty().NotNull();
            RuleFor(e => e.MemberPatronymic).MinimumLength(3).MaximumLength(20).NotEmpty().NotNull();
            RuleFor(e => e.BirthDate).NotNull().NotEmpty();
            RuleFor(e => e.BirthPlace).MinimumLength(4).MaximumLength(20).NotEmpty().NotNull();

        }
    }
}
