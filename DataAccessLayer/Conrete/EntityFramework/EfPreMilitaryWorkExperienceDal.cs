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
        public EfPreMilitaryWorkExperienceDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<PreMilitaryWorkExperienceGetDto>> GetAllExperiencesAsync()
        {
            
                var query = await (from e in _context.PreMilitaryWorkExperiences
                                   join p in _context.MilitaryPersonels on e.PersonelId equals p.Id
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
        public async Task<List<PreMilitaryWorkExperienceGetDto>> GetAllExpereiencesByPersonelId(int personelId)
        {
            
                var query = await (from e in _context.PreMilitaryWorkExperiences
                                   join p in _context.MilitaryPersonels on e.PersonelId equals p.Id
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
         public async Task<PreMilitaryWorkExperienceGetDto> GetExperienceById(int id)
        {
            
                var query = await (from e in _context.PreMilitaryWorkExperiences
                                   join p in _context.MilitaryPersonels on e.PersonelId equals p.Id
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
