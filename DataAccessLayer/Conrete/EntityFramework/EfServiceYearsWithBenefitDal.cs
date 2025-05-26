using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfServiceYearsWithBenefitDal : EfEntityRepositoryBase<ServiceYearsWithBenefit,MilitaryBaseContext>, IServiceYearsWithBenefitDal
    {
        public EfServiceYearsWithBenefitDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
    }
   

}
