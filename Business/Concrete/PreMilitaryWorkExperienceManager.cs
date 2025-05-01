using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.PreMilitaryWorkExperienceDtos;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class PreMilitaryWorkExperienceManager:IPreMilitaryWorkExperienceService
    {
        private readonly IPreMilitaryWorkExperienceDal _experienceDal;
        private readonly IMapper _mapper;

        public PreMilitaryWorkExperienceManager(IPreMilitaryWorkExperienceDal experienceDal, IMapper mapper)
        {
            _experienceDal = experienceDal;
            _mapper = mapper;
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PreMilitaryWorkExperienceGetDto>>> GetAllExperiencesAsync()
        {
            var list=await _experienceDal.GetAllExperiencesAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PreMilitaryWorkExperienceGetDto>>(list);
            }
            return new ErrorDataResult<List<PreMilitaryWorkExperienceGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PreMilitaryWorkExperienceGetDto>>> GetAllExperiencesByPersonelIdAsync(int personelId)
        {
            var list = await _experienceDal.GetAllExpereiencesByPersonelId(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PreMilitaryWorkExperienceGetDto>>(list);
            }
            return new ErrorDataResult<List<PreMilitaryWorkExperienceGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<PreMilitaryWorkExperienceGetDto>> GetExperienceByIdAsync(int id)
        {
            var entity = await _experienceDal.GetExperienceById(id);
            if (entity == null)
            {
                return new ErrorDataResult<PreMilitaryWorkExperienceGetDto>(Messages.EntityNotFound);
            }
            return new SuccessDataResult<PreMilitaryWorkExperienceGetDto>(entity);
        }
        [CacheRemoveAspect("IPreMilitaryWorkExperienceService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(PreMilitaryWorkExperienceValidator))]
        public async Task<IResult> AddExperienceAsync(PreMilitaryWorkExperienceAddDto dto)
        {
            var entity = _mapper.Map<PreMilitaryWorkExperience>(dto);
            await _experienceDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IPreMilitaryWorkExperienceService.Get")]
        [SecuredOperation("admin,cmd.update")]
        [ValidationAspect(typeof(PreMilitaryWorkExperienceValidator))]
        public async Task<IResult> UpdateExperienceAsync(PreMilitaryWorkExperienceUpdateDto dto)
        {
            var entity=await _experienceDal.GetAsync(p => p.Id == dto.Id);
            _mapper.Map(dto, entity);
            await _experienceDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IPreMilitaryWorkExperienceService.Get")]
        [SecuredOperation("admin")]
        [ValidationAspect(typeof(PreMilitaryWorkExperienceValidator))]
        public async Task<IResult> DeleteExperienceAsync(int id)
        {
            var entity=await _experienceDal.GetAsync(p => p.Id == id);
            await _experienceDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
