using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryRankDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;
using System.Drawing;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryRankDal : EfEntityRepositoryBase<MilitaryRank,MilitaryBaseContext>, IMilitaryRankDal
    {
        public async Task<List<MilitaryRankGetDto>> GetAllRanksAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from r in context.MilitaryRanks
                                   join p in context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in context.Injunctions on r.InjunctionId equals i.Id
                                   select new MilitaryRankGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       InjunctionId = r.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       RankName = r.RankName
                                   }).ToListAsync();
                return query;
            }
            
        }
        public async Task<List<MilitaryRankGetDto>> GetAllRanksByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from r in context.MilitaryRanks
                                   join p in context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in context.Injunctions on r.InjunctionId equals i.Id
                                   select new MilitaryRankGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       InjunctionId = r.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       RankName = r.RankName
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }
            
        }
        public async Task<List<MilitaryRankGetDto>> GetAllRanksByInjunctionIdAsync(int injunctionId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from r in context.MilitaryRanks
                                   join p in context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in context.Injunctions on r.InjunctionId equals i.Id
                                   select new MilitaryRankGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       InjunctionId = r.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       RankName = r.RankName
                                   }).Where(p=>p.InjunctionId==injunctionId).ToListAsync();
                return query;
            }
            
        }
        public async Task<MilitaryRankGetDto> GetRankByIdAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from r in context.MilitaryRanks
                                   join p in context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in context.Injunctions on r.InjunctionId equals i.Id
                                   select new MilitaryRankGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       InjunctionId = r.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       RankName = r.RankName
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            }
        }

    }
   

}
