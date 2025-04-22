using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.PersonelForeignTravelDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelForeignTravelDal:EfEntityRepositoryBase<MilitaryPersonelForeignTravel,MilitaryBaseContext>,IMilitaryPersonelForeignTravelDal
    {
        public async Task<List<PersonelForeignTravelGetDto>> GetAllTravelsAsync()
        {
            using (MilitaryBaseContext context=new())
            {
                var query =await  (from f in context.MilitaryPersonelForeignTravels
                             join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                             join i in context.Injunctions on f.InjunctionId equals i.Id
                             select new PersonelForeignTravelGetDto
                             {
                                 Id = f.Id,
                                 PersonelId = f.PersonelId,
                                 InjunctionId = f.InjunctionId,
                                 InjunctionNumber = i.InjunctionNumber,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 StartDate = f.StartDate,
                                 EndDate = f.EndDate,
                                 Record = f.Record,
                                 TravellingCountryName = f.TravellingCountryName,
                                 TravelReason = f.TravelReason

                             }).ToListAsync();
                return query;
                            
            }
        }
        public async Task<List<PersonelForeignTravelGetDto>> GetAllByInjunctionIdAsync(int injunctionId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query =await  (from f in context.MilitaryPersonelForeignTravels
                             join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                             join i in context.Injunctions on f.InjunctionId equals i.Id
                             select new PersonelForeignTravelGetDto
                             {
                                 Id = f.Id,
                                 PersonelId = f.PersonelId,
                                 InjunctionId = f.InjunctionId,
                                 InjunctionNumber = i.InjunctionNumber,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 StartDate = f.StartDate,
                                 EndDate = f.EndDate,
                                 Record = f.Record,
                                 TravellingCountryName = f.TravellingCountryName,
                                 TravelReason = f.TravelReason

                             }).Where(p=>p.InjunctionId==injunctionId).ToListAsync();
                return query;
                            
            }
        }
        public async Task<List<PersonelForeignTravelGetDto>> GetAllByPersonelIdAsync(int personelId)
        {
            using (MilitaryBaseContext context=new())
            {
                var query =await  (from f in context.MilitaryPersonelForeignTravels
                             join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                             join i in context.Injunctions on f.InjunctionId equals i.Id
                             select new PersonelForeignTravelGetDto
                             {
                                 Id = f.Id,
                                 PersonelId = f.PersonelId,
                                 InjunctionId = f.InjunctionId,
                                 InjunctionNumber = i.InjunctionNumber,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 StartDate = f.StartDate,
                                 EndDate = f.EndDate,
                                 Record = f.Record,
                                 TravellingCountryName = f.TravellingCountryName,
                                 TravelReason = f.TravelReason

                             }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
                            
            }
        }
        public async Task<PersonelForeignTravelGetDto> GetByIdAsync(int id)
        {
            using (MilitaryBaseContext context=new())
            {
                var query =await  (from f in context.MilitaryPersonelForeignTravels
                             join p in context.MilitaryPersonels on f.PersonelId equals p.Id
                             join i in context.Injunctions on f.InjunctionId equals i.Id
                             select new PersonelForeignTravelGetDto
                             {
                                 Id = f.Id,
                                 PersonelId = f.PersonelId,
                                 InjunctionId = f.InjunctionId,
                                 InjunctionNumber = i.InjunctionNumber,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 StartDate = f.StartDate,
                                 EndDate = f.EndDate,
                                 Record = f.Record,
                                 TravellingCountryName = f.TravellingCountryName,
                                 TravelReason = f.TravelReason

                             }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
                            
            }
        }

    }
   

}
