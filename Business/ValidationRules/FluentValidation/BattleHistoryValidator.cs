
using FluentValidation;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.ValidationRules.FluentValidation
{
    public class BattleHistoryValidator : AbstractValidator<BattleHistory>
    {
        public BattleHistoryValidator()
        {
            RuleFor(p => p.BattleName).MinimumLength(10);
            //RuleFor(p => p.UnitPrice).GreaterThan(0);
            //RuleFor(p => p.UnitPrice).NotEmpty();
            //RuleFor(p => p.ProductName).NotEmpty();
            //RuleFor(p => p.ProductName).MinimumLength(2);
            //RuleFor(p => p.UnitPrice).GreaterThanOrEqualTo(10).When(p => p.CategoryId == 1);
            //RuleFor(p => p.ProductName).Must(StartsWithA);
        }

        private bool StartsWithA(string arg)
        {
            return arg.StartsWith("A");
        }
    }
}
