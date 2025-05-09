using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.FamilyMembersInServiceDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfFamilyMembersInServiceDal : EfEntityRepositoryBase<FamilyMembersInService, MilitaryBaseContext>, IFamilyMemberInServiceDal
    {
        public async Task<List<FamilyMembersInServiceGetDto>> GetAllFamilyMembersInServiceAsync()
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from f in context.FamilyMembersInServices
                                   join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                                   join m in context.FamilyMembers on f.MemberId equals m.Id
                                   select new FamilyMembersInServiceGetDto
                                   {
                                       Id = f.Id,
                                       PersonelId = f.PersonelId,
                                       MemberId = f.MemberId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       Record = f.Record
                                   }).ToListAsync();
                return query;
            }
        }
        public async Task<List<FamilyMembersInServiceGetDto>> GetAllFamilyMembersInServiceByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from f in context.FamilyMembersInServices
                                   join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                                   join m in context.FamilyMembers on f.MemberId equals m.Id
                                   select new FamilyMembersInServiceGetDto
                                   {
                                       Id = f.Id,
                                       PersonelId = f.PersonelId,
                                       MemberId = f.MemberId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       Record = f.Record
                                   }).Where(p => p.PersonelId == personelId).ToListAsync();
                return query;
            }
        }
        public async Task<List<FamilyMembersInServiceGetDto>> GetAllFamilyMembersInServiceByMemberIdAsync(int memberId)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from f in context.FamilyMembersInServices
                                   join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                                   join m in context.FamilyMembers on f.MemberId equals m.Id
                                   select new FamilyMembersInServiceGetDto
                                   {
                                       Id = f.Id,
                                       PersonelId = f.PersonelId,
                                       MemberId = f.MemberId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       Record = f.Record
                                   }).Where(p => p.PersonelId == memberId).ToListAsync();
                return query;
            }
        }
        public async Task<FamilyMembersInServiceGetDto> GetFamilyMemberInServiceByIdAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from f in context.FamilyMembersInServices
                                   join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                                   join m in context.FamilyMembers on f.MemberId equals m.Id
                                   select new FamilyMembersInServiceGetDto
                                   {
                                       Id = f.Id,
                                       PersonelId = f.PersonelId,
                                       MemberId = f.MemberId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       Record = f.Record
                                   }).FirstOrDefaultAsync(p => p.Id == id);
                return query;
            }
        }

    }
}
