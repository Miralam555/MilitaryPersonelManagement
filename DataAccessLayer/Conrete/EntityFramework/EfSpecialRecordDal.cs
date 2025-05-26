using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conrete.EntityFramework
{
   public class EfSpecialRecordDal : EfEntityRepositoryBase<SpecialRecord,MilitaryBaseContext>, ISpecialRecordDal
    {
        public EfSpecialRecordDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
    }
   

}
