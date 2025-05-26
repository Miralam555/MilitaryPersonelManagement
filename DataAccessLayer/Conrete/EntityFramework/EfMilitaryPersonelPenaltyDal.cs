using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryPersonelPenaltyDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelPenaltyDal : EfEntityRepositoryBase<MilitaryPersonelPenalty, MilitaryBaseContext>, IMilitaryPersonelPenaltyDal
    {
        public EfMilitaryPersonelPenaltyDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<PenaltyGetDto>> GetAllPenaltiesAsync()
        {
            
                var query = await (from p in _context.MilitaryPersonelPenalties
                                   join mp in _context.MilitaryPersonels on p.PersonelId equals mp.Id
                                   join pt in _context.MilitaryPenaltyTypes on p.PenaltyTypeId
                                   equals pt.Id
                                   join i in _context.Injunctions on p.InjunctionId equals i.Id
                                   select new PenaltyGetDto
                                   {
                                       Id = p.Id,
                                       InjunctionId = p.InjunctionId,
                                       PenaltyTypeId = p.PenaltyTypeId,
                                       PersonelId = p.PersonelId,
                                       PersonelName = mp.PersonelName,
                                       PersonelSurname = mp.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PenaltyType = pt.PenaltyType,
                                       PenaltyDescription = p.PenaltyDescription,
                                       Record = p.Record
                                   }).ToListAsync();
                return query;
            
        }
        public async Task<List<PenaltyGetDto>> GetAllPenaltiesByPersonelIdAsync(int personelId)
        {
            
                var query = await (from p in _context.MilitaryPersonelPenalties
                                   join mp in _context.MilitaryPersonels on p.PersonelId equals mp.Id
                                   join pt in _context.MilitaryPenaltyTypes on p.PenaltyTypeId
                                   equals pt.Id
                                   join i in _context.Injunctions on p.InjunctionId equals i.Id
                                   select new PenaltyGetDto
                                   {
                                       Id = p.Id,
                                       InjunctionId = p.InjunctionId,
                                       PenaltyTypeId = p.PenaltyTypeId,
                                       PersonelId = p.PersonelId,
                                       PersonelName = mp.PersonelName,
                                       PersonelSurname = mp.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PenaltyType = pt.PenaltyType,
                                       PenaltyDescription = p.PenaltyDescription,
                                       Record = p.Record
                                   }).Where(p => p.PersonelId == personelId).ToListAsync();
                return query;
            
        }
        public async Task<List<PenaltyGetDto>> GetAllPenaltiesByPenaltyTypeIdAsync(int penaltyTypeId)
        {
            
                var query = await (from p in _context.MilitaryPersonelPenalties
                                   join mp in _context.MilitaryPersonels on p.PersonelId equals mp.Id
                                   join pt in _context.MilitaryPenaltyTypes on p.PenaltyTypeId
                                   equals pt.Id
                                   join i in _context.Injunctions on p.InjunctionId equals i.Id
                                   select new PenaltyGetDto
                                   {
                                       Id = p.Id,
                                       InjunctionId = p.InjunctionId,
                                       PenaltyTypeId = p.PenaltyTypeId,
                                       PersonelId = p.PersonelId,
                                       PersonelName = mp.PersonelName,
                                       PersonelSurname = mp.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PenaltyType = pt.PenaltyType,
                                       PenaltyDescription = p.PenaltyDescription,
                                       Record = p.Record
                                   }).Where(p => p.PenaltyTypeId == penaltyTypeId).ToListAsync();
                return query;
            
        }
        public async Task<List<PenaltyGetDto>> GetAllPenaltiesByInjunctionIdAsync(int injunctionId)
        {
           
                var query = await (from p in _context.MilitaryPersonelPenalties
                                   join mp in _context.MilitaryPersonels on p.PersonelId equals mp.Id
                                   join pt in _context.MilitaryPenaltyTypes on p.PenaltyTypeId
                                   equals pt.Id
                                   join i in _context.Injunctions on p.InjunctionId equals i.Id
                                   select new PenaltyGetDto
                                   {
                                       Id = p.Id,
                                       InjunctionId = p.InjunctionId,
                                       PenaltyTypeId = p.PenaltyTypeId,
                                       PersonelId = p.PersonelId,
                                       PersonelName = mp.PersonelName,
                                       PersonelSurname = mp.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PenaltyType = pt.PenaltyType,
                                       PenaltyDescription = p.PenaltyDescription,
                                       Record = p.Record
                                   }).Where(p => p.PenaltyTypeId == injunctionId).ToListAsync();
                return query;
            
        }

        public async Task<PenaltyGetDto> GetPenaltyByIdAsync(int id)
        {
            
                var query = await (from p in _context.MilitaryPersonelPenalties
                                   join mp in _context.MilitaryPersonels on p.PersonelId equals mp.Id
                                   join pt in _context.MilitaryPenaltyTypes on p.PenaltyTypeId
                                   equals pt.Id
                                   join i in _context.Injunctions on p.InjunctionId equals i.Id
                                   select new PenaltyGetDto
                                   {
                                       Id = p.Id,
                                       InjunctionId = p.InjunctionId,
                                       PenaltyTypeId = p.PenaltyTypeId,
                                       PersonelId = p.PersonelId,
                                       PersonelName = mp.PersonelName,
                                       PersonelSurname = mp.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PenaltyType = pt.PenaltyType,
                                       PenaltyDescription = p.PenaltyDescription,
                                       Record = p.Record
                                   }).FirstOrDefaultAsync(p => p.Id == id);
                return query;
            
        }

    }


}
