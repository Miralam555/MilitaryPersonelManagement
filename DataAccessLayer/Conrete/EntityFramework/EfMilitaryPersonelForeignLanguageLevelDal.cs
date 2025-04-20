using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.FamilyMemberForeignTravelDtos;
using Entities.DTOs.PersonelForeignLanguageLevel;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelForeignLanguageLevelDal : EfEntityRepositoryBase<MilitaryPersonelForeignLanguageLevel,MilitaryBaseContext>, IMilitaryPersonelForeignLanguageLevelDal
    {
        public async Task<List<PersonelForeignLanguageLevelGetDto>> GetAllLevelAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from l in context.MilitaryPersonelForeignLanguageLevels
                                   join p in context.MilitaryPersonels on l.PersonelId equals p.Id
                                   join i in context.Injunctions on l.AllowanceInjunctionId equals i.Id
                                   select new PersonelForeignLanguageLevelGetDto
                                   {
                                       Id = l.Id,
                                       PersonelId = l.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       AllowanceInjunctionId = l.AllowanceInjunctionId,
                                       InjunctionNumber = i.InjunctionNumber,
                                       LanguageLevel = l.LanguageLevel,
                                       LanguageName = l.LanguageName,
                                       Record = l.Record
                                   }).ToListAsync();
                return query;
            }
        }
        public async Task<List<PersonelForeignLanguageLevelGetDto>> GetAllLevelByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from l in context.MilitaryPersonelForeignLanguageLevels
                                   join p in context.MilitaryPersonels on l.PersonelId equals p.Id
                                   join i in context.Injunctions on l.AllowanceInjunctionId equals i.Id
                                   select new PersonelForeignLanguageLevelGetDto
                                   {
                                       Id = l.Id,
                                       PersonelId = l.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       AllowanceInjunctionId = l.AllowanceInjunctionId,
                                       InjunctionNumber = i.InjunctionNumber,
                                       LanguageLevel = l.LanguageLevel,
                                       LanguageName = l.LanguageName,
                                       Record = l.Record
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }
        }
        public async Task<List<PersonelForeignLanguageLevelGetDto>> GetAllLevelByInjunctionIdAsync(int injunctionId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from l in context.MilitaryPersonelForeignLanguageLevels
                                   join p in context.MilitaryPersonels on l.PersonelId equals p.Id
                                   join i in context.Injunctions on l.AllowanceInjunctionId equals i.Id
                                   select new PersonelForeignLanguageLevelGetDto
                                   {
                                       Id = l.Id,
                                       PersonelId = l.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       AllowanceInjunctionId = l.AllowanceInjunctionId,
                                       InjunctionNumber = i.InjunctionNumber,
                                       LanguageLevel = l.LanguageLevel,
                                       LanguageName = l.LanguageName,
                                       Record = l.Record
                                   }).Where(p=>p.AllowanceInjunctionId==injunctionId).ToListAsync();
                return query;
            }
        }
        public async Task<PersonelForeignLanguageLevelGetDto> GetLevelByIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from l in context.MilitaryPersonelForeignLanguageLevels
                                   join p in context.MilitaryPersonels on l.PersonelId equals p.Id
                                   join i in context.Injunctions on l.AllowanceInjunctionId equals i.Id
                                   select new PersonelForeignLanguageLevelGetDto
                                   {
                                       Id = l.Id,
                                       PersonelId = l.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       AllowanceInjunctionId = l.AllowanceInjunctionId,
                                       InjunctionNumber = i.InjunctionNumber,
                                       LanguageLevel = l.LanguageLevel,
                                       LanguageName = l.LanguageName,
                                       Record = l.Record
                                   }).FirstOrDefaultAsync(p => p.Id == id);
                return query;
            }
        }


    }
   

}
