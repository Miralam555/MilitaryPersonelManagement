using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.CrimeRecordDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfCrimeRecordDal : EfEntityRepositoryBase<CrimeRecord, MilitaryBaseContext>, ICrimeRecordDal
    {
       
        public EfCrimeRecordDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<CrimeRecordGetDto>> GetAllCrimeRecordsAsync()
        {

            
                var query = await (from c in _context.CrimeRecords
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join m in _context.FamilyMembers on c.MemberId equals m.Id
                                   select new CrimeRecordGetDto
                                   {
                                       Id = c.Id,
                                       MemberId = c.MemberId,
                                       PersonelId = c.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       ChargeDuration = c.ChargeDuration,
                                       ChargeDescription = c.ChargeDescription,
                                       PenalInstitution = c.PenalInstitution,
                                       Record = c.Record
                                   }).ToListAsync();
                return query;
            
        }
        public async Task<List<CrimeRecordGetDto>> GetAllCrimeRecordsByMemberIdAsync(int memberId)
        {

            
                var query = await (from c in _context.CrimeRecords
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join m in _context.FamilyMembers on c.MemberId equals m.Id
                                   select new CrimeRecordGetDto
                                   {
                                       Id = c.Id,
                                       MemberId = c.MemberId,
                                       PersonelId = c.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       ChargeDuration = c.ChargeDuration,
                                       ChargeDescription = c.ChargeDescription,
                                       PenalInstitution = c.PenalInstitution,
                                       Record = c.Record
                                   }).Where(p => p.MemberId == memberId).ToListAsync();
                return query;
            
        }
        public async Task<List<CrimeRecordGetDto>> GetAllCrimeRecordsByPersonelIdAsync(int personelId)
        {

            
                var query = await (from c in _context.CrimeRecords
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join m in _context.FamilyMembers on c.MemberId equals m.Id
                                   select new CrimeRecordGetDto
                                   {
                                       Id = c.Id,
                                       MemberId = c.MemberId,
                                       PersonelId = c.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       ChargeDuration = c.ChargeDuration,
                                       ChargeDescription = c.ChargeDescription,
                                       PenalInstitution = c.PenalInstitution,
                                       Record = c.Record
                                   }).Where(p => p.PersonelId == personelId).ToListAsync();
                return query;
            
        }
        public async Task<CrimeRecordGetDto> GetCrimeRecordByIdAsync(int id)
        {

           
                var query = await (from c in _context.CrimeRecords
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join m in _context.FamilyMembers on c.MemberId equals m.Id
                                   select new CrimeRecordGetDto
                                   {
                                       Id = c.Id,
                                       MemberId = c.MemberId,
                                       PersonelId = c.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       ChargeDuration = c.ChargeDuration,
                                       ChargeDescription = c.ChargeDescription,
                                       PenalInstitution = c.PenalInstitution,
                                       Record = c.Record
                                   }).FirstOrDefaultAsync(p => p.Id == id);
                return query;
            
        }

    }


}
