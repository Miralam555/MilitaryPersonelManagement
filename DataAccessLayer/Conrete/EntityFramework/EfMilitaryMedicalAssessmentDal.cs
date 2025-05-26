using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryMedicalAssessmentDal : EfEntityRepositoryBase<MilitaryMedicalAssessment,MilitaryBaseContext>, IMilitaryMedicalAssessmentDal
    {
     
        public EfMilitaryMedicalAssessmentDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<MilitaryMedicalAssessmentGetDto>> GetAllAssessmentsAsync()
        {
            var query = await (from m in _context.MilitaryMedicalAssessments
                                   join p in _context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new MilitaryMedicalAssessmentGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       Diagnosis = m.Diagnosis,
                                       AssesmentDate = m.AssesmentDate,
                                       Opinion = m.Opinion,
                                       Record = m.Record
                                   }).ToListAsync();
                return query;
            
        }
        public async Task<List<MilitaryMedicalAssessmentGetDto>> GetAllAssessmentsByPersonelIdAsync(int personelId)
        {
           
                var query = await (from m in _context.MilitaryMedicalAssessments
                                   join p in _context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new MilitaryMedicalAssessmentGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       Diagnosis = m.Diagnosis,
                                       AssesmentDate = m.AssesmentDate,
                                       Opinion = m.Opinion,
                                       Record = m.Record
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            
        }

         public async Task<MilitaryMedicalAssessmentGetDto> GetByIdAssessmentAsync(int id)
        {
            
                var query = await (from m in _context.MilitaryMedicalAssessments
                                   join p in _context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new MilitaryMedicalAssessmentGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       Diagnosis = m.Diagnosis,
                                       AssesmentDate = m.AssesmentDate,
                                       Opinion = m.Opinion,
                                       Record = m.Record
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            
        }

    }
   

}
