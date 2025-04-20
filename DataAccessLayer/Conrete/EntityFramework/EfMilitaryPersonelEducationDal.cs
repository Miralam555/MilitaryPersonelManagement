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

        public async Task<List<EducationGetDto>> GetAllEducationsAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from e in context.MilitaryPersonelEducations
                             join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                             join t in context.EducationTypes on e.EducationTypeId equals t.Id
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
        }

        public async Task<List<EducationGetDto>> GetAllEducationByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from e in context.MilitaryPersonelEducations
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join t in context.EducationTypes on e.EducationTypeId equals t.Id
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
        }
         public async Task<EducationGetDto> GetEducationByIdAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from e in context.MilitaryPersonelEducations
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join t in context.EducationTypes on e.EducationTypeId equals t.Id
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
   

}
