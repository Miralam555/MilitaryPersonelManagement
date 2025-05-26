using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.PersonelSpecialSkillDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelSpecialSkillDal : EfEntityRepositoryBase<MilitaryPersonelSpecialSkill,MilitaryBaseContext>, IMilitaryPersonelSpecialSkillDal
    {
        public EfMilitaryPersonelSpecialSkillDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async Task<List<PersonelSpecialSkillGetDto>> GetAllSkillsAsync()
        {
           
                var query = await (from s in _context.MilitaryPersonelSpecialSkills
                                   join p in _context.MilitaryPersonels on s.PersonelId equals p.Id
                                   select new PersonelSpecialSkillGetDto
                                   {
                                       Id = s.Id,
                                       PersonelId = s.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       Skill = s.Skill
                                   }).ToListAsync();
                return query;
            
            
        }
        public async Task<List<PersonelSpecialSkillGetDto>> GetAllSkillsByPersonelIdAsync(int personelId)
        {
          
                var query = await (from s in _context.MilitaryPersonelSpecialSkills
                                   join p in _context.MilitaryPersonels on s.PersonelId equals p.Id
                                   select new PersonelSpecialSkillGetDto
                                   {
                                       Id = s.Id,
                                       PersonelId = s.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       Skill = s.Skill
                                   }).Where(p=>p.PersonelId==personelId).ToListAsync();
                return query;
            
            
        }
        public async Task<PersonelSpecialSkillGetDto> GetSkillByIdAsync(int id)
        {
           
                var query = await (from s in _context.MilitaryPersonelSpecialSkills
                                   join p in _context.MilitaryPersonels on s.PersonelId equals p.Id
                                   select new PersonelSpecialSkillGetDto
                                   {
                                       Id = s.Id,
                                       PersonelId = s.PersonelId,
                                       PersonelName = p.PersonelName,
                                       PersonelSurname = p.PersonelSurname,
                                       Skill = s.Skill
                                   }).FirstOrDefaultAsync(p=>p.Id==id);
                return query;
            
            
        }

    }
   

}
