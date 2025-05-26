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
        public EfMilitaryRankDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<MilitaryRankGetDto>> GetAllRanksAsync()
        {
            
                var query = await (from r in _context.MilitaryRanks
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.InjunctionId equals i.Id
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
        public async Task<List<MilitaryRankGetDto>> GetAllRanksByPersonelIdAsync(int personelId)
        {
            
                var query = await (from r in _context.MilitaryRanks
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.InjunctionId equals i.Id
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
        public async Task<List<MilitaryRankGetDto>> GetAllRanksByInjunctionIdAsync(int injunctionId)
        {
            
                var query = await (from r in _context.MilitaryRanks
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.InjunctionId equals i.Id
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
        public async Task<MilitaryRankGetDto> GetRankByIdAsync(int id)
        {
          
                var query = await (from r in _context.MilitaryRanks
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.InjunctionId equals i.Id
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
