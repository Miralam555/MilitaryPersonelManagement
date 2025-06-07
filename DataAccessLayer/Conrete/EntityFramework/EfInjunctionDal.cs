using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.InjunctionDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfInjunctionDal : EfEntityRepositoryBase<Injunction, MilitaryBaseContext>,IInjunctionDal
    {
       
        public EfInjunctionDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<InjunctionGetDto>> GetAllInjunctionWithDetailsAsync()
        {
            
                var query = await (from i in _context.Injunctions
                                   join p in _context.MilitaryPersonels on i.IssuedByPersonelId equals p.Id
                                   join it in _context.InjunctionTypes on i.InjunctionTypeId equals it.Id
                                   select new InjunctionGetDto
                                   {
                                       Id = i.Id,
                                       InjunctionTypeId = i.InjunctionTypeId,
                                       IssuedByPersonelId = i.IssuedByPersonelId,
                                       InjunctionNumber = i.InjunctionNumber,
                                       InjunctionName = it.InjunctionName,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjuctionStartDate = i.InjuctionStartDate,
                                       InjunctionIsActive = i.InjunctionIsActive
                                   }).AsNoTracking().ToListAsync();
                return query;
            
        }

        public async Task<List<InjunctionGetDto>> GetAllInjunctionsByPersonelIdAsync(int personelId)
        {
            
                var query = await (from i in _context.Injunctions
                                   join p in _context.MilitaryPersonels on i.IssuedByPersonelId equals p.Id
                                   join it in _context.InjunctionTypes on i.InjunctionTypeId equals it.Id
                                   select new InjunctionGetDto
                                   {
                                       Id = i.Id,
                                       InjunctionTypeId = i.InjunctionTypeId,
                                       IssuedByPersonelId = i.IssuedByPersonelId,
                                       InjunctionNumber = i.InjunctionNumber,
                                       InjunctionName = it.InjunctionName,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjuctionStartDate = i.InjuctionStartDate,
                                       InjunctionIsActive = i.InjunctionIsActive
                                   }).Where(p=>p.IssuedByPersonelId==personelId).AsNoTracking().ToListAsync();
                return query;

            
        }



        public async Task<InjunctionGetDto> GetInjunctionByIdAsync(int id)
        {
          
                var query = await (from i in _context.Injunctions
                                   join p in _context.MilitaryPersonels on i.IssuedByPersonelId equals p.Id
                                   join it in _context.InjunctionTypes on i.InjunctionTypeId equals it.Id
                                   select new InjunctionGetDto
                                   {
                                       Id = i.Id,
                                       InjunctionTypeId = i.InjunctionTypeId,
                                       IssuedByPersonelId = i.IssuedByPersonelId,
                                       InjunctionNumber = i.InjunctionNumber,
                                       InjunctionName = it.InjunctionName,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjuctionStartDate = i.InjuctionStartDate,
                                       InjunctionIsActive = i.InjunctionIsActive
                                   }).SingleOrDefaultAsync(p => p.Id == id);
                return query;

            
        }

    }


}
