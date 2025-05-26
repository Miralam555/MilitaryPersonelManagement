using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using MyMilitaryFinalProject.Entities.Concrete;
using Entities.DTOs.EducationDtos;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelEducationDal : EfEntityRepositoryBase<MilitaryPersonelEducation,MilitaryBaseContext>, IMilitaryPersonelEducationDal
    {
        
        public EfMilitaryPersonelEducationDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<EducationGetDto>> GetAllEducationsAsync()
        {
              var query = await (from e in _context.MilitaryPersonelEducations
                             join p in _context.MilitaryPersonels on e.PersonelId equals p.Id
                             join t in _context.EducationTypes on e.EducationTypeId equals t.Id
                             select new EducationGetDto
                             {
                                 Id = e.Id,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 PersonelId = e.PersonelId,
                                 EducationTypeId = e.EducationTypeId,
                                 Degree = e.Degree,
                                 EducationTypeName = t.EducationTypeName,
                                 GraduationYear = e.GraduationYear,
                                 InstitutionName = e.InstitutionName,
                                 Specialization = e.Specialization
                             }).ToListAsync();
                return query;
            
        }

        public async Task<List<EducationGetDto>> GetAllEducationByPersonelIdAsync(int personelId)
        {
           
                var query = await (from e in _context.MilitaryPersonelEducations
                                   join p in _context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join t in _context.EducationTypes on e.EducationTypeId equals t.Id
                                   select new EducationGetDto
                                   {
                                       Id = e.Id,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       PersonelId = e.PersonelId,
                                       EducationTypeId = e.EducationTypeId,
                                       Degree = e.Degree,
                                       EducationTypeName = t.EducationTypeName,
                                       GraduationYear = e.GraduationYear,
                                       InstitutionName = e.InstitutionName,
                                       Specialization = e.Specialization
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            
        }
         public async Task<EducationGetDto> GetEducationByIdAsync(int id)
        {
            
                var query = await (from e in _context.MilitaryPersonelEducations
                                   join p in _context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join t in _context.EducationTypes on e.EducationTypeId equals t.Id
                                   select new EducationGetDto
                                   {
                                       Id = e.Id,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       PersonelId = e.PersonelId,
                                       EducationTypeId = e.EducationTypeId,
                                       Degree = e.Degree,
                                       EducationTypeName = t.EducationTypeName,
                                       GraduationYear = e.GraduationYear,
                                       InstitutionName = e.InstitutionName,
                                       Specialization = e.Specialization
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            
        }


    }
   

}
