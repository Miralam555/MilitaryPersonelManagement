using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Performance;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Business;
using Core.Utilities.Results;
using DataAccess.Abstract;
using DataAccess.Conrete.EntityFramework.Context;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
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
            var entity = await _militaryPersonelDal.GetByIdPersonelDetails(dto.Id);
            _mapper.Map(dto, entity);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _militaryPersonelDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
    
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<MilitaryPersonel>>> GetAllPersonelsAsync()
        {
            List<MilitaryPersonel> militaryPersonels= await _militaryPersonelDal.GetAllPersonelDetails();
            if (militaryPersonels is null)
            {
                return new ErrorDataResult<List<MilitaryPersonel>>(Messages.NoData);
            }

            return new SuccessDataResult<List<MilitaryPersonel>>(militaryPersonels);

        }
       
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<MilitaryPersonel>> GetPersonelById(int id)
        {
            MilitaryPersonel personel = await _militaryPersonelDal.GetByIdPersonelDetails(id);
            
            if(personel is null)
            {
               return  new ErrorDataResult<MilitaryPersonel>(Messages.EntityNotFound);
            }
         
            return new SuccessDataResult<MilitaryPersonel   >(personel);

        }
       //Delete emeliyyati yoxdur arxivde qalsin deye ve ya soft delete istifade etmek olar
    }
}
