using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Entities;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.MilitaryMedicalAssessmentDtos;
using Entities.DTOs.PersonelForeignTravelDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PersonelForeignTravelManager : IMilitaryPersonelForeignTravelService
    {
        private readonly IMilitaryPersonelForeignTravelDal _personelForeignTravelDal;
        private readonly IMapper _mapper;

        public PersonelForeignTravelManager(IMilitaryPersonelForeignTravelDal personelForeignTravelDal, IMapper mapper)
        {
            _personelForeignTravelDal = personelForeignTravelDal;
            _mapper = mapper;
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelForeignTravelGetDto>>> GetAllTravelsAsync()
        {
            var list = await _personelForeignTravelDal.GetAllTravelsAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelForeignTravelGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelForeignTravelGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelForeignTravelGetDto>>> GetAllTravelsByInjunctionIdAsync(int injunctionId)
        {
            var list = await _personelForeignTravelDal.GetAllByInjunctionIdAsync(injunctionId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelForeignTravelGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelForeignTravelGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelForeignTravelGetDto>>> GetAllTravelsByPersonelIdAsync(int personelId)
        {
            var list = await _personelForeignTravelDal.GetAllByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelForeignTravelGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelForeignTravelGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<PersonelForeignTravelGetDto>> GetByIdAsync(int id)
        {
            var entity = await _personelForeignTravelDal.GetByIdAsync(id);
            if (entity == null)
            {
                return new ErrorDataResult<PersonelForeignTravelGetDto>(Messages.NoData);

            }
            return new SuccessDataResult<PersonelForeignTravelGetDto>(entity);
        }
        [CacheRemoveAspect("IMilitaryPersonelForeignTravelService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(PersonelForeignTravelValidator))]
        public async Task<IResult> AddTravelAsync(PersonelForeignTravelAddDto dto)
        {
            var entity=_mapper.Map<MilitaryPersonelForeignTravel>(dto);
            await _personelForeignTravelDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
         [CacheRemoveAspect("IMilitaryPersonelForeignTravelService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(PersonelForeignTravelValidator))]
        public async Task<IResult> UpdateTravelAsync(PersonelForeignTravelUpdateDto dto)
        {
            var entity=await _personelForeignTravelDal.GetAsync(p => p.Id == dto.Id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            _mapper.Map(dto, entity);
            await _personelForeignTravelDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
         [CacheRemoveAspect("IMilitaryPersonelForeignTravelService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PersonelForeignTravelValidator))]
        public async Task<IResult> DeleteTravelAsync(int id)
        {
            var entity = await _personelForeignTravelDal.GetAsync(p => p.Id == id);
            if (entity == null)
            {
                return new ErrorDataResult<MilitaryMedicalAssessmentGetDto>(Messages.EntityNotFound);
            }
            await _personelForeignTravelDal.DeleteAsync(entity);
            
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
