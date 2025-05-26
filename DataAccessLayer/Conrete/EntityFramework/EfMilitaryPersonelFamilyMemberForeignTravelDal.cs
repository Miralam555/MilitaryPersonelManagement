using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.FamilyMemberForeignTravelDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelFamilyMemberForeignTravelDal : EfEntityRepositoryBase<MilitaryPersonelFamilyMemberForeignTravel,MilitaryBaseContext>, IMilitaryPersonelFamilyMemberForeignTravelDal
    {
       

        public EfMilitaryPersonelFamilyMemberForeignTravelDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<FamilyMemberForeignTravelGetDto>> GetAllTravelsAsync()
        {
            
                var query = await (from f in _context.MilitaryPersonelFamilyMemberForeignTravels
                             join p in _context.FamilyMembers on f.MemberId equals p.Id
                             select new FamilyMemberForeignTravelGetDto
                             {
                                 Id = f.Id,
                                 MemberId = f.Id,
                                 MemberName = p.MemberName,
                                 MemberSurName = p.MemberSurName,
                                 EndDate = f.EndDate,
                                 StartDate = f.StartDate,
                                 TravellingCountryName = f.TravellingCountryName,
                                 TravelReason = f.TravelReason,
                                 Record = f.Record
                             }).ToListAsync();
                return query;

            
        }
        public async Task<List<FamilyMemberForeignTravelGetDto>> GetAllTravelsByMemberIdAsync(int memberId)
        {
            
                var query = await (from f in _context.MilitaryPersonelFamilyMemberForeignTravels
                             join p in _context.FamilyMembers on f.MemberId equals p.Id
                             select new FamilyMemberForeignTravelGetDto
                             {
                                 Id = f.Id,
                                 MemberId = f.Id,
                                 MemberName = p.MemberName,
                                 MemberSurName = p.MemberSurName,
                                 EndDate = f.EndDate,
                                 StartDate = f.StartDate,
                                 TravellingCountryName = f.TravellingCountryName,
                                 TravelReason = f.TravelReason,
                                 Record = f.Record
                             }).Where(p=>p.MemberId==memberId).ToListAsync();
                return query;

            
        }
        public async Task<FamilyMemberForeignTravelGetDto> GetTravelByIdAsync(int id)
        {
            
                var query = await (from f in _context.MilitaryPersonelFamilyMemberForeignTravels
                                   join p in _context.FamilyMembers on f.MemberId equals p.Id
                                   select new FamilyMemberForeignTravelGetDto
                                   {
                                       Id = f.Id,
                                       MemberId = f.Id,
                                       MemberName = p.MemberName,
                                       MemberSurName = p.MemberSurName,
                                       EndDate = f.EndDate,
                                       StartDate = f.StartDate,
                                       TravellingCountryName = f.TravellingCountryName,
                                       TravelReason = f.TravelReason,
                                       Record = f.Record
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;

            
        }

    }
   

}
