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
        public async Task<List<InjunctionGetDto>> GetAllInjunctionWithDetailsAsync()
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from i in context.Injunctions
                                   join p in context.MilitaryPersonels on i.IssuedByPersonelId equals p.Id
                                   join it in context.InjunctionTypes on i.InjunctionTypeId equals it.Id
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
                                   }).ToListAsync();
                return query;
            }
        }

        public async Task<List<InjunctionGetDto>> GetAllInjunctionsByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from i in context.Injunctions
                                   join p in context.MilitaryPersonels on i.IssuedByPersonelId equals p.Id
                                   join it in context.InjunctionTypes on i.InjunctionTypeId equals it.Id
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
                                   }).Where(p=>p.IssuedByPersonelId==personelId).ToListAsync();
                return query;

            }
        }



        public async Task<InjunctionGetDto> GetInjunctionByIdAsync(int id)
        {
            using (MilitaryBaseContext context = new())
            {
                var query = await (from i in context.Injunctions
                                   join p in context.MilitaryPersonels on i.IssuedByPersonelId equals p.Id
                                   join it in context.InjunctionTypes on i.InjunctionTypeId equals it.Id
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


}
