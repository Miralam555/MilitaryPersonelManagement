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
        

        public EfMilitaryPersonelDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async  Task<List<MilitaryPersonel>> GetAllPersonelDetails()
        {
           
                List<MilitaryPersonel>  personels = await _context.MilitaryPersonels.Include(p => p.MilitaryPersonelInfo).ThenInclude(e => e.MaritalStatus).ToListAsync();
                return personels;
            
            
        }
        public async Task<MilitaryPersonel> GetByIdPersonelDetails(int id)
        {
           
                MilitaryPersonel personel = await _context.MilitaryPersonels.Include(p => p.MilitaryPersonelInfo).ThenInclude(e => e.MaritalStatus).FirstOrDefaultAsync(p => p.Id == id);
                return personel;

            
        }
    }
   

}
