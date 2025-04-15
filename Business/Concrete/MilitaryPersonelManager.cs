using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryPersonelDtos;
using Microsoft.EntityFrameworkCore;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitaryPersonelManager : IMilitaryPersonelService
    {
        private readonly IMilitaryPersonelDal _militaryPersonelDal;
        private readonly IMapper _mapper;
        public MilitaryPersonelManager(IMilitaryPersonelDal militaryPersonelDal, IMapper mapper)
        {
            _mapper = mapper;
            _militaryPersonelDal = militaryPersonelDal;
        }
       
        [CacheRemoveAspect("IMilitaryPersonselService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryPersonelValidator))]
        public async Task<IResult> PersonelAddAsync(MilitaryPersonelAddDto dto)
        {

            var personel = _mapper.Map<MilitaryPersonel>(dto);

            await _militaryPersonelDal.AddAsync(personel);
            return new SuccessResult(Messages.SuccessfullyAdded);
        } 
      
        [CacheRemoveAspect("IMilitaryPersonselService.Get")]
        [ValidationAspect(typeof(MilitaryPersonelValidator))]
        [SecuredOperation("admin,cmd.update")]
        public async Task<IResult> PersonelUpdateAsync(MilitaryPersonelUpdateDto dto)
        {
            var personel = _mapper.Map<MilitaryPersonel>(dto);
            await _militaryPersonelDal.UpdateAsync(personel);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryPersonelGetDto>>> GetAllPersonelAsync()
        {
            List<MilitaryPersonel> militaryPersonels= await _militaryPersonelDal.GetAllPersonelDetails();

            return new SuccessDataResult<List<MilitaryPersonelGetDto>>(_mapper.Map<List<MilitaryPersonelGetDto>>(militaryPersonels));

        }
       
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<MilitaryPersonelGetDto>> GetByIdPersonel(int id)
        {
            MilitaryPersonel personel = await _militaryPersonelDal.GetByIdPersonelDetails(id);
            
         
            return new SuccessDataResult<MilitaryPersonelGetDto>(_mapper.Map<MilitaryPersonelGetDto>(personel));

        }
       
    }
}
