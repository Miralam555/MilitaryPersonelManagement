using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelPenaltyDal : EfEntityRepositoryBase<MilitaryPersonelPenalty,MilitaryBaseContext>, IMilitaryPersonelPenaltyDal
    {
        public async Task<List<MilitaryPersonelPenalty>> GetAllPenaltiesAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                return await context.MilitaryPersonelPenalties.Include(p => p.PenaltyType).Include(p => p.Personel).Include(p => p.Injunction).ThenInclude(p => p.InjunctionType).ToListAsync();
            }
        }
        public async Task<List<MilitaryPersonelPenalty>> GetAllPenaltiesByPersonelIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                return await context.MilitaryPersonelPenalties.Include(p => p.PenaltyType).Include(p => p.Personel).Include(p => p.Injunction).ThenInclude(p => p.InjunctionType).Where(p=>p.PersonelId==id).ToListAsync();
            }
        }
        public async Task<MilitaryPersonelPenalty> GetPenaltyByIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                return await context.MilitaryPersonelPenalties.Include(p => p.PenaltyType).Include(p => p.Personel).Include(p => p.Injunction).ThenInclude(p => p.InjunctionType).Where(p=>p.PersonelId==id).FirstOrDefaultAsync(p=>p.Id==id);
            }
        }

    }
   

}
