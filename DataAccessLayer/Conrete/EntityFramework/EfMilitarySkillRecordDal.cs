using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitarySkillRecordDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitarySkillRecordDal : EfEntityRepositoryBase<MilitarySkillRecord, MilitaryBaseContext>, IMilitarySkillRecordDal
    {
        public EfMilitarySkillRecordDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<MilitarySkillRecordGetDto>> GetAllSkillRecordsAsync()
        {
           
                var query = await (from r in _context.MilitarySkillRecords
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.IssuedByInjunctionId equals i.Id
                                   join ia in _context.Injunctions on r.ApprovedByInjunctionId equals ia.Id
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
        public async Task<List<MilitarySkillRecordGetDto>> GetAllSkillRecordsByPersonelIdAsync(int personelId)
        {
            
                var query = await (from r in _context.MilitarySkillRecords
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.IssuedByInjunctionId equals i.Id
                                   join ia in _context.Injunctions on r.ApprovedByInjunctionId equals ia.Id
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
        public async Task<MilitarySkillRecordGetDto> GetSkillRecordByIdAsync(int id)
        {
           
                var query = await (from r in _context.MilitarySkillRecords
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.IssuedByInjunctionId equals i.Id
                                   join ia in _context.Injunctions on r.ApprovedByInjunctionId equals ia.Id
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
