using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.ProfessionalDevelopmentCourse;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfProfessionalDevelopmentCourseDal : EfEntityRepositoryBase<ProfessionalDevelopmentCourse,MilitaryBaseContext>, IProfessionalDevelopmentCourseDal
    {
        public EfProfessionalDevelopmentCourseDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<ProfessionalDevelopmentCourseGetDto>> GetAllCoursesAsync()
        {
            
                var query = await (from c in _context.ProfessionalDevelopmentCourses
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join i in _context.Injunctions on c.InjunctionId equals i.Id
                                   select new ProfessionalDevelopmentCourseGetDto
                                   {
                                       PersonelId = c.PersonelId,
                                       InjunctionId = c.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       CourseName = c.CourseName,
                                       OrganizedLocation = c.OrganizedLocation,
                                       Duration = c.Duration,
                                       Specialization = c.Specialization,
                                       StartDate = c.StartDate,
                                       IsCurrentMilitary = c.IsCurrentMilitary
                                   }).ToListAsync();
                return query;
            
        }
        public async Task<List<ProfessionalDevelopmentCourseGetDto>> GetAllCoursesByPersonelIdAsync(int personelId)
        {
            
                var query = await (from c in _context.ProfessionalDevelopmentCourses
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join i in _context.Injunctions on c.InjunctionId equals i.Id
                                   select new ProfessionalDevelopmentCourseGetDto
                                   {
                                       PersonelId = c.PersonelId,
                                       InjunctionId = c.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       CourseName = c.CourseName,
                                       OrganizedLocation = c.OrganizedLocation,
                                       Duration = c.Duration,
                                       Specialization = c.Specialization,
                                       StartDate = c.StartDate,
                                       IsCurrentMilitary = c.IsCurrentMilitary
                                   }).Where(c=>c.PersonelId==personelId).ToListAsync();
                return query;
            
        }
        public async Task<List<ProfessionalDevelopmentCourseGetDto>> GetAllCoursesByInjunctionIdAsync(int injunctionId)
        {
            
                var query = await (from c in _context.ProfessionalDevelopmentCourses
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join i in _context.Injunctions on c.InjunctionId equals i.Id
                                   select new ProfessionalDevelopmentCourseGetDto
                                   {
                                       PersonelId = c.PersonelId,
                                       InjunctionId = c.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       CourseName = c.CourseName,
                                       OrganizedLocation = c.OrganizedLocation,
                                       Duration = c.Duration,
                                       Specialization = c.Specialization,
                                       StartDate = c.StartDate,
                                       IsCurrentMilitary = c.IsCurrentMilitary
                                   }).Where(c=>c.InjunctionId==injunctionId).ToListAsync();
                return query;
            
        }
        public async Task<ProfessionalDevelopmentCourseGetDto> GetByIdAsync(int id)
        {
            
                var query = await (from c in _context.ProfessionalDevelopmentCourses
                                   join p in _context.MilitaryPersonels on c.PersonelId equals p.Id
                                   join i in _context.Injunctions on c.InjunctionId equals i.Id
                                   select new ProfessionalDevelopmentCourseGetDto
                                   {
                                       Id=c.Id,
                                       PersonelId = c.PersonelId,
                                       InjunctionId = c.InjunctionId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       InjunctionNumber = i.InjunctionNumber,
                                       CourseName = c.CourseName,
                                       OrganizedLocation = c.OrganizedLocation,
                                       Duration = c.Duration,
                                       Specialization = c.Specialization,
                                       StartDate = c.StartDate,
                                       IsCurrentMilitary = c.IsCurrentMilitary
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            
        }

    }
   

}
