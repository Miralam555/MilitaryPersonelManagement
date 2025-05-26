using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryPersonelRecognitionDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelRecognitionDal : EfEntityRepositoryBase<MilitaryPersonelRecognition,MilitaryBaseContext>, IMilitaryPersonelRecognitionDal
    {
        public EfMilitaryPersonelRecognitionDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<PersonelRecognitionGetDto>> GetAllRecognitionsAsync()
        {
           
                var query = await (from r in _context.MilitaryPersonelRecognitions
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.Injunctionİd equals i.Id
                                   select new PersonelRecognitionGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       Injunctionİd = r.Injunctionİd,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       RecognitionDescription = r.RecognitionDescription,
                                       Record = r.Record
                                   }).ToListAsync();
                return query;
            
        }
        public async Task<List<PersonelRecognitionGetDto>> GetAllRecognitionsByInjunctionIdAsync(int injunctionId)
        {
           
                var query = await (from r in _context.MilitaryPersonelRecognitions
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.Injunctionİd equals i.Id
                                   select new PersonelRecognitionGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       Injunctionİd = r.Injunctionİd,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       RecognitionDescription = r.RecognitionDescription,
                                       Record = r.Record
                                   }).Where(p=>p.Injunctionİd==injunctionId).ToListAsync();
                return query;
            
        }
        public async Task<List<PersonelRecognitionGetDto>> GetAllRecognitionsByPersonelIdAsync(int personelId)
        {
            
                var query = await (from r in _context.MilitaryPersonelRecognitions
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.Injunctionİd equals i.Id
                                   select new PersonelRecognitionGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       Injunctionİd = r.Injunctionİd,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       RecognitionDescription = r.RecognitionDescription,
                                       Record = r.Record
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            
        }
        public async Task<PersonelRecognitionGetDto> GetRecognitionByIdAsync(int id)
        {
            
                var query = await (from r in _context.MilitaryPersonelRecognitions
                                   join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                                   join i in _context.Injunctions on r.Injunctionİd equals i.Id
                                   select new PersonelRecognitionGetDto
                                   {
                                       Id = r.Id,
                                       PersonelId = r.PersonelId,
                                       Injunctionİd = r.Injunctionİd,
                                       InjunctionNumber = i.InjunctionNumber,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       RecognitionDescription = r.RecognitionDescription,
                                       Record = r.Record
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            
        }

    }
   

}
