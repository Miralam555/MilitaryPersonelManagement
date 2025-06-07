using Core.DataAccess.EntityFramework;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryPersonelDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;
using System.Runtime.CompilerServices;

namespace DataAccess.Conrete.EntityFramework
{
    public class EfMilitaryPersonelDal:EfEntityRepositoryBase<MilitaryPersonel,MilitaryBaseContext>,IMilitaryPersonelDal
    {
        

        public EfMilitaryPersonelDal(MilitaryBaseContext context) : base(context)
        {
            _context = context;
        }
        public async  Task<List<PersonelGetDto>> GetAllPersonelDetails()
        {

            //List<MilitaryPersonel>  personels = await _context.MilitaryPersonels.Include(p => p.MilitaryPersonelInfo).ThenInclude(e => e.MaritalStatus).ToListAsync();
            //return personels;
            var query = await(from p in _context.MilitaryPersonels
                        join pinfo in _context.MilitaryPersonelInfos on p.Id equals pinfo.Id
                        join m in _context.MaritalStatuses on pinfo.MaritalStatusId equals m.Id
                        select new PersonelGetDto
                        {
                            Id=p.Id,
                            BirthDate=p.BirthDate,
                            BirthPlace=p.BirthPlace,
                            BloodGroup=pinfo.BloodGroup,
                            CurrentAddress=pinfo.CurrentAddress,
                            Height=pinfo.Height,
                            IdentityCardNumber = pinfo.IdentityCardNumber,
                            Nationality = pinfo.Nationality,
                            Patronymic = p.Patronymic,
                            PersonelName=p.PersonelName,
                            PersonelSurname=p.PersonelSurname,
                            Pin = pinfo.Pin,
                            RegistrationAddress= pinfo.RegistrationAddress,
                            StatusName=m.StatusName,
                            Weight= pinfo.Weight
                        }).AsNoTracking().ToListAsync();
            return query;
            
        }
        public async Task<PersonelGetDto> GetByIdPersonelDetails(int id)
        {

            //MilitaryPersonel personel = await _context.MilitaryPersonels.Include(p => p.MilitaryPersonelInfo).ThenInclude(e => e.MaritalStatus).FirstOrDefaultAsync(p => p.Id == id);
            //return personel;
            var query = await (from p in _context.MilitaryPersonels
                               join pinfo in _context.MilitaryPersonelInfos on p.Id equals pinfo.Id
                               join m in _context.MaritalStatuses on pinfo.MaritalStatusId equals m.Id
                               select new PersonelGetDto
                               {
                                   Id = p.Id,
                                   BirthDate = p.BirthDate,
                                   BirthPlace = p.BirthPlace,
                                   BloodGroup = pinfo.BloodGroup,
                                   CurrentAddress = pinfo.CurrentAddress,
                                   Height = pinfo.Height,
                                   IdentityCardNumber = pinfo.IdentityCardNumber,
                                   Nationality = pinfo.Nationality,
                                   Patronymic = p.Patronymic,
                                   PersonelName = p.PersonelName,
                                   PersonelSurname = p.PersonelSurname,
                                   Pin = pinfo.Pin,
                                   RegistrationAddress = pinfo.RegistrationAddress,
                                   StatusName = m.StatusName,
                                   Weight = pinfo.Weight
                               }).AsNoTracking().SingleOrDefaultAsync(p=>p.Id==id);
            return query;

        }
    }
   

}
