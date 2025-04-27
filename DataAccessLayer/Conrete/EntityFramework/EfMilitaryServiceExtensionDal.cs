using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryServiceExtensionDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryServiceExtensionDal : EfEntityRepositoryBase<MilitaryServiceExtension,MilitaryBaseContext>, IMilitaryServiceExtensionDal
    {
        public async Task<List<MilitaryServiceExtensionGetDto>> GetAllExtensionsAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from e in context.MilitaryServiceExtensions
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join i in context.Injunctions on e.InjunctionId equals i.Id
                                   select new MilitaryServiceExtensionGetDto
                                   {
                                       Id = e.Id,
                                       PersonelId = e.PersonelId,
                                       InjunctionId = e.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = e.StartDate,
                                       EndDate = e.EndDate,
                                       Record = e.Record
                                   }).ToListAsync();
                return query;
            }
        }
        public async Task<List<MilitaryServiceExtensionGetDto>> GetAllExtensionsByInjunctionIdAsync(int injunctionId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from e in context.MilitaryServiceExtensions
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join i in context.Injunctions on e.InjunctionId equals i.Id
                                   select new MilitaryServiceExtensionGetDto
                                   {
                                       Id = e.Id,
                                       PersonelId = e.PersonelId,
                                       InjunctionId = e.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = e.StartDate,
                                       EndDate = e.EndDate,
                                       Record = e.Record
                                   }).Where(p=>p.InjunctionId==injunctionId).ToListAsync();
                return query;
            }
        }
        public async Task<List<MilitaryServiceExtensionGetDto>> GetAllExtensionsByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from e in context.MilitaryServiceExtensions
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join i in context.Injunctions on e.InjunctionId equals i.Id
                                   select new MilitaryServiceExtensionGetDto
                                   {
                                       Id = e.Id,
                                       PersonelId = e.PersonelId,
                                       InjunctionId = e.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = e.StartDate,
                                       EndDate = e.EndDate,
                                       Record = e.Record
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }
        }
        public async Task<MilitaryServiceExtensionGetDto> GetExtensionByIdAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from e in context.MilitaryServiceExtensions
                                   join p in context.MilitaryPersonels on e.PersonelId equals p.Id
                                   join i in context.Injunctions on e.InjunctionId equals i.Id
                                   select new MilitaryServiceExtensionGetDto
                                   {
                                       Id = e.Id,
                                       PersonelId = e.PersonelId,
                                       InjunctionId = e.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = e.StartDate,
                                       EndDate = e.EndDate,
                                       Record = e.Record
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            }
        }

    }
   

}
