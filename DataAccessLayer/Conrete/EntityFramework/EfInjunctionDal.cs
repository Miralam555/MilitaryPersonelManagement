using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfInjunctionDal : EfEntityRepositoryBase<Injunction, MilitaryBaseContext>, IInjunctionDal
    {
        public async Task<List<Injunction>> GetAllInjunctionWithDetailsAsync()
        {
            using (MilitaryBaseContext context = new())
            {
                return await context.Injunctions.Include(p => p.InjunctionType).ToListAsync();
            }
        }

        public async Task<List<Injunction>> GetAllInjunctionsByIssuedPersonelIdWithDetailsAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                return await context.Injunctions.Include(p => p.InjunctionType).Where(p => p.IssuedByPersonelId == id).ToListAsync();
            }
        }



        public async Task<Injunction> GetByIdInjunctionWithDetailsAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                return await context.Injunctions.Include(p => p.InjunctionType).FirstOrDefaultAsync(p => p.Id == id);
            }
        }

    }


}
