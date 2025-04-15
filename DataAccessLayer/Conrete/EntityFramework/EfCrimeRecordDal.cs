using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfCrimeRecordDal : EfEntityRepositoryBase<CrimeRecord,MilitaryBaseContext>, ICrimeRecordDal 
    { 
    }
   

}
