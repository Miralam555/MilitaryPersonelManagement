using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryMedicalAssessmentDal : EfEntityRepositoryBase<MilitaryMedicalAssessment,MilitaryBaseContext>, IMilitaryMedicalAssessmentDal
    {
        public async Task<List<MilitaryMedicalAssessment>> GetAllAssessmentsAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                return await context.MilitaryMedicalAssessments.Include(p => p.Personel).ThenInclude(p => p.MilitaryPersonelInfo).ToListAsync();
            }
        }
        public async Task<List<MilitaryMedicalAssessment>> GetAllAssessmentsByPersonelIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                return await context.MilitaryMedicalAssessments.Include(p => p.Personel).ThenInclude(p => p.MilitaryPersonelInfo).Where(p=>p.PersonelId==id).ToListAsync();
            }
        }

         public async Task<MilitaryMedicalAssessment> GetByIdAssessmentAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                return await context.MilitaryMedicalAssessments.Include(p => p.Personel).ThenInclude(p => p.MilitaryPersonelInfo).FirstOrDefaultAsync(p=>p.Id==id);
            }
        }

    }
   

}
