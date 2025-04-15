using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;
using System.Runtime.CompilerServices;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelDal:EfEntityRepositoryBase<MilitaryPersonel,MilitaryBaseContext>,IMilitaryPersonelDal
    {
        public async  Task<List<MilitaryPersonel>> GetAllPersonelDetails()
        {
            using (MilitaryBaseContext context = new MilitaryBaseContext())
            {
                List<MilitaryPersonel>  personels = await context.MilitaryPersonels.Include(p => p.MilitaryPersonelInfo).ThenInclude(e => e.MaritalStatus).ToListAsync();
                return personels;
            }
            
        }
        public async Task<MilitaryPersonel> GetByIdPersonelDetails(int id)
        {
            using (MilitaryBaseContext context = new MilitaryBaseContext())
            {
                MilitaryPersonel personel = await context.MilitaryPersonels.Include(p => p.MilitaryPersonelInfo).ThenInclude(e => e.MaritalStatus).FirstOrDefaultAsync(p => p.Id == id);
                return personel;

            }
        }
    }
   

}
