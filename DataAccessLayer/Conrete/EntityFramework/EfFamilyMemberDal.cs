using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.FamilyMemberDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfFamilyMemberDal : EfEntityRepositoryBase<FamilyMember,MilitaryBaseContext>, IFamilyMemberDal
    {
        public async Task<List<FamilyMemberGetDto>> GetAllMembersAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from m in context.FamilyMembers
                                   join p in context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new FamilyMemberGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.Id,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       BirthPlace = m.BirthPlace,
                                       BirthDate = m.BirthDate,
                                       MemberPatronymic = m.MemberPatronymic,
                                       Occupation = m.Occupation,
                                       RelationShip = m.RelationShip
                                   }).ToListAsync();
                return query;
            }
        }
        public async Task<List<FamilyMemberGetDto>> GetAllMembersByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from m in context.FamilyMembers
                                   join p in context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new FamilyMemberGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.Id,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       BirthPlace = m.BirthPlace,
                                       BirthDate = m.BirthDate,
                                       MemberPatronymic = m.MemberPatronymic,
                                       Occupation = m.Occupation,
                                       RelationShip = m.RelationShip
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            }
        }
        public async Task<FamilyMemberGetDto> GetMemberByIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                var query = await (from m in context.FamilyMembers
                                   join p in context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new FamilyMemberGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.Id,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       BirthPlace = m.BirthPlace,
                                       BirthDate = m.BirthDate,
                                       MemberPatronymic = m.MemberPatronymic,
                                       Occupation = m.Occupation,
                                       RelationShip = m.RelationShip
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            }
        }


    }
   

}
