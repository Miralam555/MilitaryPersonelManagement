using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitarySkillRecordDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitarySkillRecordDal : EfEntityRepositoryBase<MilitarySkillRecord,MilitaryBaseContext>, IMilitarySkillRecordDal
    {
        public async Task<List<MilitarySkillRecordGetDto>> GetAllSkillRecordsAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from r in context.MilitarySkillRecords
                                   join p in context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in context.Injunctions on r.IssuedByInjunctionId equals i.Id
                                   join ia in context.Injunctions on r.ApprovedByInjunctionId equals ia.Id
                                   select new MilitarySkillRecordGetDto
                                   {
                                       Id = r.Id,
                                       IssuedByInjunctionId = r.IssuedByInjunctionId,
                                       ApprovedByInjunctionId = r.ApprovedByInjunctionId,
                                       PersonelId = p.Id,
                                       InjunctionNumber = i.InjunctionNumber,
                                       ApprovedInjunctionNumber = ia.InjunctionNumber,
                                       SkillDegree = r.SkillDegree,
                                       Record = r.Record
                                   }).ToListAsync();
                return query;
            }
        }
        public async Task<List<MilitarySkillRecordGetDto>> GetAllSkillRecordsByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from r in context.MilitarySkillRecords
                                   join p in context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in context.Injunctions on r.IssuedByInjunctionId equals i.Id
                                   join ia in context.Injunctions on r.ApprovedByInjunctionId equals ia.Id
                                   select new MilitarySkillRecordGetDto
                                   {
                                       Id = r.Id,
                                       IssuedByInjunctionId = r.IssuedByInjunctionId,
                                       ApprovedByInjunctionId = r.ApprovedByInjunctionId,
                                       PersonelId = p.Id,
                                       InjunctionNumber = i.InjunctionNumber,
                                       ApprovedInjunctionNumber = ia.InjunctionNumber,
                                       SkillDegree = r.SkillDegree,
                                       Record = r.Record
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }
        }
        public async Task<MilitarySkillRecordGetDto> GetSkillRecordByIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from r in context.MilitarySkillRecords
                                   join p in context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in context.Injunctions on r.IssuedByInjunctionId equals i.Id
                                   join ia in context.Injunctions on r.ApprovedByInjunctionId equals ia.Id
                                   select new MilitarySkillRecordGetDto
                                   {
                                       Id = r.Id,
                                       IssuedByInjunctionId = r.IssuedByInjunctionId,
                                       ApprovedByInjunctionId = r.ApprovedByInjunctionId,
                                       PersonelId = p.Id,
                                       InjunctionNumber = i.InjunctionNumber,
                                       ApprovedInjunctionNumber = ia.InjunctionNumber,
                                       SkillDegree = r.SkillDegree,
                                       Record = r.Record
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            }
        }

    }
   

}
