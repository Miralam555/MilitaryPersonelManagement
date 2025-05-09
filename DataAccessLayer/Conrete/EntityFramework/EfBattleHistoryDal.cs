using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.BattleHistoryDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfBattleHistoryDal : EfEntityRepositoryBase<BattleHistory,MilitaryBaseContext>, IBattleHistoryDal
    {
        public async Task<List<BattleHistoryGetDto>> GetAllHistoriesAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from h in context.BattleHistories
                                   join p in context.MilitaryPersonels on h.PersonelId equals p.Id
                                   select new BattleHistoryGetDto
                                   {
                                       Id = h.Id,
                                       PersonelId = h.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       BattleName = h.BattleName,
                                       InjuryOrDiseaseType = h.InjuryOrDiseaseType,
                                       Position = h.Position,
                                       StartDate = h.StartDate,
                                       EndDate = h.EndDate,
                                       VeteranNote = h.VeteranNote
                                   }).ToListAsync();
                return query;
            }
        }
        public async Task<List<BattleHistoryGetDto>> GetAllHistoriesByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from h in context.BattleHistories
                                   join p in context.MilitaryPersonels on h.PersonelId equals p.Id
                                   select new BattleHistoryGetDto
                                   {
                                       Id = h.Id,
                                       PersonelId = h.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       BattleName = h.BattleName,
                                       InjuryOrDiseaseType = h.InjuryOrDiseaseType,
                                       Position = h.Position,
                                       StartDate = h.StartDate,
                                       EndDate = h.EndDate,
                                       VeteranNote = h.VeteranNote
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }
        }
        public async Task<BattleHistoryGetDto> GetHistoryByIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from h in context.BattleHistories
                                   join p in context.MilitaryPersonels on h.PersonelId equals p.Id
                                   select new BattleHistoryGetDto
                                   {
                                       Id = h.Id,
                                       PersonelId = h.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       BattleName = h.BattleName,
                                       InjuryOrDiseaseType = h.InjuryOrDiseaseType,
                                       Position = h.Position,
                                       StartDate = h.StartDate,
                                       EndDate = h.EndDate,
                                       VeteranNote = h.VeteranNote
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            }
        }

    }
   

}
