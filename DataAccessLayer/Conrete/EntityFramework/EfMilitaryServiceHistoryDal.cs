using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryServiceHistoryDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryServiceHistoryDal : EfEntityRepositoryBase<MilitaryServiceHistory,MilitaryBaseContext>, IMilitaryServiceHistoryDal
    {
        public async Task<List<MilitaryServiceHistoryGetDto>> GetAllServiceHistoryAsync()
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from s in context.MilitaryServiceHistories
                                   join i in context.Injunctions on s.InjunctionId equals i.Id
                                   join p in context.MilitaryPersonels on s.PersonelId equals p.Id
                                   select new MilitaryServiceHistoryGetDto
                                   {
                                       Id = s.Id,
                                       InjunctionId = s.InjunctionId,
                                       PersonelId = s.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                       OrganizationName = s.OrganizationName,
                                       OfficialRank = s.OfficialRank,
                                       Position = s.Position,
                                       IsCurrentMilitary = s.IsCurrentMilitary
                                   }).ToListAsync();
                return query;
            }

        }
        public async Task<List<MilitaryServiceHistoryGetDto>> GetAllServiceHistoryByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from s in context.MilitaryServiceHistories
                                   join i in context.Injunctions on s.InjunctionId equals i.Id
                                   join p in context.MilitaryPersonels on s.PersonelId equals p.Id
                                   select new MilitaryServiceHistoryGetDto
                                   {
                                       Id = s.Id,
                                       InjunctionId = s.InjunctionId,
                                       PersonelId = s.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                       OrganizationName = s.OrganizationName,
                                       OfficialRank = s.OfficialRank,
                                       Position = s.Position,
                                       IsCurrentMilitary = s.IsCurrentMilitary
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }

        }
        public async Task<List<MilitaryServiceHistoryGetDto>> GetAllServiceHistoryByInjunctionIdAsync(int injunctionId)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from s in context.MilitaryServiceHistories
                                   join i in context.Injunctions on s.InjunctionId equals i.Id
                                   join p in context.MilitaryPersonels on s.PersonelId equals p.Id
                                   select new MilitaryServiceHistoryGetDto
                                   {
                                       Id = s.Id,
                                       InjunctionId = s.InjunctionId,
                                       PersonelId = s.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                       OrganizationName = s.OrganizationName,
                                       OfficialRank = s.OfficialRank,
                                       Position = s.Position,
                                       IsCurrentMilitary = s.IsCurrentMilitary
                                   }).Where(p=>p.InjunctionId==injunctionId).ToListAsync();
                return query;
            }

        }
        public async Task<MilitaryServiceHistoryGetDto> GetServiceHistoryByIdAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from s in context.MilitaryServiceHistories
                                   join i in context.Injunctions on s.InjunctionId equals i.Id
                                   join p in context.MilitaryPersonels on s.PersonelId equals p.Id
                                   select new MilitaryServiceHistoryGetDto
                                   {
                                       Id = s.Id,
                                       InjunctionId = s.InjunctionId,
                                       PersonelId = s.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       StartDate = s.StartDate,
                                       EndDate = s.EndDate,
                                       OrganizationName = s.OrganizationName,
                                       OfficialRank = s.OfficialRank,
                                       Position = s.Position,
                                       IsCurrentMilitary = s.IsCurrentMilitary
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            }

        }

    }
   
}
