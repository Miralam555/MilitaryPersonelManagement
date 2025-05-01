using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.PreMilitaryWorkExperienceDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfPreMilitaryWorkExperienceDal : EfEntityRepositoryBase<PreMilitaryWorkExperience,MilitaryBaseContext>, IPreMilitaryWorkExperienceDal
    {
        public async Task<List<PreMilitaryWorkExperienceGetDto>> GetAllExperiencesAsync()
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from e in context.PreMilitaryWorkExperiences
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   select new PreMilitaryWorkExperienceGetDto
                                   {
                                       Id = e.Id,
                                       PersonelId = e.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       CompanyName = e.CompanyName,
                                       Position = e.Position,
                                       WorkEndDate = e.WorkEndDate,
                                       WorkStartDate = e.WorkStartDate
                                   }).ToListAsync();
                return query;
            }
            
        }
        public async Task<List<PreMilitaryWorkExperienceGetDto>> GetAllExpereiencesByPersonelId(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from e in context.PreMilitaryWorkExperiences
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   select new PreMilitaryWorkExperienceGetDto
                                   {
                                       Id = e.Id,
                                       PersonelId = e.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       CompanyName = e.CompanyName,
                                       Position = e.Position,
                                       WorkEndDate = e.WorkEndDate,
                                       WorkStartDate = e.WorkStartDate
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }
        }
         public async Task<PreMilitaryWorkExperienceGetDto> GetExperienceById(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from e in context.PreMilitaryWorkExperiences
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   select new PreMilitaryWorkExperienceGetDto
                                   {
                                       Id = e.Id,
                                       PersonelId = e.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       CompanyName = e.CompanyName,
                                       Position = e.Position,
                                       WorkEndDate = e.WorkEndDate,
                                       WorkStartDate = e.WorkStartDate
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            }
        }

    }
   

}
