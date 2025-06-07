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
       

        public EfFamilyMemberDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<FamilyMemberGetDto>> GetAllMembersAsync()
        {
            
                var query = await (from m in _context.FamilyMembers
                                   join p in _context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new FamilyMemberGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       BirthPlace = m.BirthPlace,
                                       BirthDate = m.BirthDate,
                                       MemberPatronymic = m.MemberPatronymic,
                                       Occupation = m.Occupation,
                                       RelationShip = m.RelationShip
                                   }).AsNoTracking().ToListAsync();
                return query;
            
        }
        public async Task<List<FamilyMemberGetDto>> GetAllMembersByPersonelIdAsync(int personelId)
        {
            
                var query = await (from m in _context.FamilyMembers
                                   join p in _context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new FamilyMemberGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       MemberName = m.MemberName,
                                       MemberSurName = m.MemberSurName,
                                       BirthPlace = m.BirthPlace,
                                       BirthDate = m.BirthDate,
                                       MemberPatronymic = m.MemberPatronymic,
                                       Occupation = m.Occupation,
                                       RelationShip = m.RelationShip
                                   }).Where(p=>p.PersonelId==personelId).AsNoTracking().ToListAsync();
                return query;
            
        }
        public async Task<FamilyMemberGetDto> GetMemberByIdAsync(int id)
        {
           
                var query = await (from m in _context.FamilyMembers
                                   join p in _context.MilitaryPersonels on m.PersonelId equals p.Id
                                   select new FamilyMemberGetDto
                                   {
                                       Id = m.Id,
                                       PersonelId = m.PersonelId,
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
