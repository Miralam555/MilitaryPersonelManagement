using AutoMapper;
using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Business.ValidationRules.FluentValidation;
using Core.Aspects.Autofac.Caching;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.DTOs.PersonelForeignLanguageLevel;
using MyMilitaryFinalProject.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class MilitaryPersonelForeignLanguageLevelManager: IMilitaryPersonelForeignLanguageLevelService
    {
        private readonly IMilitaryPersonelForeignLanguageLevelDal _languageLevelDal;
        private readonly IMapper _mapper;

        public MilitaryPersonelForeignLanguageLevelManager(IMilitaryPersonelForeignLanguageLevelDal languageLevelDal, IMapper mapper)
        {
            _languageLevelDal = languageLevelDal;
            _mapper = mapper;
        }

        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelForeignLanguageLevelGetDto>>> GetAllLevelAsync()
        {
            var list = await _languageLevelDal.GetAllLevelAsync();
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelForeignLanguageLevelGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelForeignLanguageLevelGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelForeignLanguageLevelGetDto>>> GetAllLevelByInjunctionIdAsync(int injunctionId)
        {
            var list = await _languageLevelDal.GetAllLevelByInjunctionIdAsync(injunctionId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelForeignLanguageLevelGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelForeignLanguageLevelGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<List<PersonelForeignLanguageLevelGetDto>>> GetAllLevelByPersonelIdAsync(int personelId)
        {
            var list = await _languageLevelDal.GetAllLevelByPersonelIdAsync(personelId);
            if (list.Count > 0)
            {
                return new SuccessDataResult<List<PersonelForeignLanguageLevelGetDto>>(list);
            }
            return new ErrorDataResult<List<PersonelForeignLanguageLevelGetDto>>(Messages.NoData);
        }
        [CacheAspect]
        [SecuredOperation("admin,cmd.get")]
        public async Task<IDataResult<PersonelForeignLanguageLevelGetDto>> GetLevelByIdAsync(int id)
        {
            var entity = await _languageLevelDal.GetLevelByIdAsync(id);
            if (entity is null)
            {
                return new ErrorDataResult<PersonelForeignLanguageLevelGetDto>(Messages.NoData);
            }
            return new SuccessDataResult<PersonelForeignLanguageLevelGetDto>(entity);
            
        }
        [CacheRemoveAspect("IMilitaryPersonelForeignLanguageLevelService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryPersonelForeignLanguageLevelValidator))]
        public async Task<IResult> AddLevelAsync(PersonelForeignLanguageLevelAddDto dto)
        {
            var entity=_mapper.Map<MilitaryPersonelForeignLanguageLevel>(dto);
            await _languageLevelDal.AddAsync(entity);
            return new SuccessResult(Messages.SuccessfullyAdded);
        }
        [CacheRemoveAspect("IMilitaryPersonelForeignLanguageLevelService.Get")]
        [SecuredOperation("admin,cmd.add")]
        [ValidationAspect(typeof(MilitaryPersonelForeignLanguageLevelValidator))]
        public async Task<IResult> UpdateLevelAsync(PersonelForeignLanguageLevelUpdateDto dto)
        {
            var entity=await _languageLevelDal.GetAsync(e => e.Id == dto.Id);
            _mapper.Map(dto, entity);
            await _languageLevelDal.UpdateAsync(entity);
            return new SuccessResult(Messages.SuccessfullyUpdated);
        }
        [CacheRemoveAspect("IMilitaryPersonelForeignLanguageLevelService.Get")]
        [SecuredOperation("admin")]
        public async Task<IResult> DeleteAsync(int id)
        {
            var entity=await _languageLevelDal.GetAsync(e => e.Id == id);
            await _languageLevelDal.DeleteAsync(entity);
            return new SuccessResult(Messages.SuccessfullyDeleted);
        }

    }
}
