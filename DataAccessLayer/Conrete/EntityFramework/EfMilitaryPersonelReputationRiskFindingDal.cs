using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.PersonelReputationRiskFindingDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelReputationRiskFindingDal : EfEntityRepositoryBase<MilitaryPersonelReputationRiskFinding,MilitaryBaseContext>, IMilitaryPersonelReputationRiskFindingDal
    {

        public EfMilitaryPersonelReputationRiskFindingDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<PersonelReputationRiskFindingGetDto>> GetAllReportsAsync()
        {
            
                var query = await (from r in _context.MilitaryPersonelReputationRiskFindings
                             join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                             select new PersonelReputationRiskFindingGetDto
                             {
                                 Id = r.Id,
                                 PersonelId = r.PersonelId,
                                 Info = r.Info,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 Record = r.Record,
                                 ReportingAgency = r.ReportingAgency
                             }).ToListAsync();
                return query;
            
        }
        public async Task<List<PersonelReputationRiskFindingGetDto>> GetAllReportsByPerosnelIdAsync(int personelId)
        {
           
                var query = await (from r in _context.MilitaryPersonelReputationRiskFindings
                             join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                             select new PersonelReputationRiskFindingGetDto
                             {
                                 Id = r.Id,
                                 PersonelId = r.PersonelId,
                                 Info = r.Info,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 Record = r.Record,
                                 ReportingAgency = r.ReportingAgency
                             }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            
        }
        public async Task<PersonelReputationRiskFindingGetDto> GetReportAsync(int id)
        {
              var query = await (from r in _context.MilitaryPersonelReputationRiskFindings
                             join p in _context.MilitaryPersonels on r.PersonelId equals p.Id
                             select new PersonelReputationRiskFindingGetDto
                             {
                                 Id = r.Id,
                                 PersonelId = r.PersonelId,
                                 Info = r.Info,
                                 PersonelName = p.PersonelName,
                                 PersonelSurname = p.PersonelSurname,
                                 Record = r.Record,
                                 ReportingAgency = r.ReportingAgency
                             }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            
        }

    }
   

}
